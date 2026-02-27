using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["TotalPrice"] == null || Session["AdvanceAmount"] == null || Session["BookingID"] == null)
            {
                lblMessage.Text = "Session data missing. Please restart the booking process.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                decimal totalPrice = Convert.ToDecimal(Session["TotalPrice"]);
                decimal advanceAmount = Convert.ToDecimal(Session["AdvanceAmount"]);
                txtAdvanceAmount.Text = advanceAmount.ToString("0.00");
                txtRemainingAmount.Text = (totalPrice - advanceAmount).ToString("0.00");
            }
            catch
            {
                lblMessage.Text = "Invalid session data format.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnPayNow_Click(object sender, EventArgs e)
    {
        if (!ValidatePayment())
            return;

        if (Session["BookingID"] == null)
        {
            lblMessage.Text = "Booking reference missing. Please restart the booking process.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Save payment details
                string paymentQuery = @"INSERT INTO Payments (BookingID, CardNumber, ExpiryDate, CVV, AmountPaid) 
                                        VALUES (@BookingID, @CardNumber, @ExpiryDate, @CVV, @AmountPaid)";

                using (SqlCommand paymentCommand = new SqlCommand(paymentQuery, connection, transaction))
                {
                    paymentCommand.Parameters.AddWithValue("@BookingID", Convert.ToInt32(Session["BookingID"]));
                    paymentCommand.Parameters.AddWithValue("@CardNumber", txtCardNumber.Text);
                    paymentCommand.Parameters.AddWithValue("@ExpiryDate", txtExpiryDate.Text);
                    paymentCommand.Parameters.AddWithValue("@CVV", txtCVV.Text);

                    decimal amountPaid;
                    if (!decimal.TryParse(txtRemainingAmount.Text, out amountPaid))
                        amountPaid = 0;

                    paymentCommand.Parameters.AddWithValue("@AmountPaid", amountPaid);

                    paymentCommand.ExecuteNonQuery();
                }

                // Update booking status
                string updateQuery = "UPDATE Bookings SET PaymentStatus = 'Paid' WHERE BookingID = @BookingID";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                {
                    updateCommand.Parameters.AddWithValue("@BookingID", Convert.ToInt32(Session["BookingID"]));
                    updateCommand.ExecuteNonQuery();
                }

                transaction.Commit();
                Response.Redirect("Confirm.aspx");
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollbackEx)
                {
                    System.Diagnostics.Debug.WriteLine("Rollback failed: " + rollbackEx.Message);
                }

                lblMessage.Text = "Payment failed: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                System.Diagnostics.Debug.WriteLine("Payment error: " + ex);
            }
        }
    }

    private bool ValidatePayment()
    {
        if (string.IsNullOrWhiteSpace(txtCardNumber.Text) ||
            string.IsNullOrWhiteSpace(txtExpiryDate.Text) ||
            string.IsNullOrWhiteSpace(txtCVV.Text))
        {
            lblMessage.Text = "Please fill in all payment details.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        return true;
    }
}
