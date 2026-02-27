using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;

public partial class BookNow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string serviceName = Request.QueryString["service"];
            string price = Request.QueryString["price"];

            lblDisplayServiceName.Text = HttpUtility.UrlDecode(serviceName);
            lblDisplayPrice.Text = HttpUtility.UrlDecode(price);

            decimal priceValue = 0;
            if (decimal.TryParse(lblDisplayPrice.Text, out priceValue))
            {
                decimal advanceAmount = priceValue * 0.25m;
                txtAdvanceAmount.Text = advanceAmount.ToString("0.00");
            }

            LoadBookedDates();
        }
    }

    private void LoadBookedDates()
    {
        try
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";
            string query = "SELECT PreferredDate FROM Bookings";

            List<DateTime> bookedDates = new List<DateTime>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bookedDates.Add(Convert.ToDateTime(reader["PreferredDate"]));
                }
            }

            ViewState["BookedDates"] = bookedDates;
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error loading booked dates.";
            System.Diagnostics.Debug.WriteLine("LoadBookedDates error: " + ex.Message);
        }
    }

    protected void calBookedDates_DayRender(object sender, DayRenderEventArgs e)
    {
        List<DateTime> dates = ViewState["BookedDates"] as List<DateTime>;

        if (e.Day.Date < DateTime.Today)
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
            e.Cell.BackColor = System.Drawing.Color.LightGray;
            e.Cell.ToolTip = "Cannot select past dates.";
        }

        if (dates != null && dates.Contains(e.Day.Date))
        {
            e.Cell.BackColor = System.Drawing.Color.LightCoral;
            e.Cell.ToolTip = "Date already booked!";
            e.Day.IsSelectable = false;
        }
    }

    protected void btnPayment_Click(object sender, EventArgs e)
    {
        if (!ValidateForm())
            return;

        int bookingId = SaveBookingToDatabase();
        if (bookingId > 0)
        {
            decimal totalPrice = Convert.ToDecimal(lblDisplayPrice.Text);
            decimal advanceAmount = totalPrice * 0.25m;

            Session["TotalPrice"] = totalPrice;
            Session["AdvanceAmount"] = advanceAmount;
            Session["BookingID"] = bookingId;

            Response.Redirect("Payment.aspx");
        }
    }

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
            string.IsNullOrWhiteSpace(txtPreferredDate.Text))
        {
            lblMessage.Text = "Please fill in all required fields.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        DateTime selectedDate;
        if (DateTime.TryParse(txtPreferredDate.Text, out selectedDate))
        {
            if (selectedDate.Date < DateTime.Today)
            {
                lblMessage.Text = "Preferred date cannot be in the past.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        }
        else
        {
            lblMessage.Text = "Invalid preferred date format.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return false;
        }

        return true;
    }

    private int SaveBookingToDatabase()
    {
        try
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";
            string query = @"INSERT INTO Bookings 
                             (CustomerName, Email, PhoneNumber, ShootType, Price, AdvanceAmount, PreferredDate, AdditionalNotes, PaymentStatus)
                             VALUES 
                             (@CustomerName, @Email, @PhoneNumber, @ShootType, @Price, @AdvanceAmount, @PreferredDate, @AdditionalNotes, @PaymentStatus);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                command.Parameters.AddWithValue("@ShootType", lblDisplayServiceName.Text);

                decimal price = decimal.Parse(lblDisplayPrice.Text.Replace("$", "").Replace(",", ""));
                decimal advanceAmount = decimal.Parse(txtAdvanceAmount.Text.Replace("$", "").Replace(",", ""));

                command.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;
                command.Parameters["@Price"].Precision = 10;
                command.Parameters["@Price"].Scale = 2;

                command.Parameters.Add("@AdvanceAmount", SqlDbType.Decimal).Value = advanceAmount;
                command.Parameters["@AdvanceAmount"].Precision = 10;
                command.Parameters["@AdvanceAmount"].Scale = 2;

                DateTime preferredDate = DateTime.Parse(txtPreferredDate.Text);
                command.Parameters.AddWithValue("@PreferredDate", preferredDate);

                if (string.IsNullOrWhiteSpace(txtAdditionalNotes.Text))
                    command.Parameters.AddWithValue("@AdditionalNotes", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@AdditionalNotes", txtAdditionalNotes.Text);

                command.Parameters.AddWithValue("@PaymentStatus", "Advance Paid");

                connection.Open();
                int newId = Convert.ToInt32(command.ExecuteScalar());

                lblMessage.Text = "Booking saved successfully! ID: " + newId;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                return newId;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error saving booking: " + ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            System.Diagnostics.Debug.WriteLine("SaveBooking error: " + ex);
            return -1;
        }
    }
}
