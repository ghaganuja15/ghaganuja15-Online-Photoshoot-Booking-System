using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewBookings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    private void BindGridView()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Bookings", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewBookings.DataSource = dt;
                GridViewBookings.DataBind();
            }
        }
    }

    protected void GridViewBookings_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int bookingId = Convert.ToInt32(GridViewBookings.DataKeys[e.RowIndex].Value);
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // First delete from Payments table
                using (SqlCommand cmdPayments = new SqlCommand("DELETE FROM Payments WHERE BookingID = @BookingID", con, transaction))
                {
                    cmdPayments.Parameters.AddWithValue("@BookingID", bookingId);
                    cmdPayments.ExecuteNonQuery();
                }

                // Then delete from Bookings table
                using (SqlCommand cmdBookings = new SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID", con, transaction))
                {
                    cmdBookings.Parameters.AddWithValue("@BookingID", bookingId);
                    cmdBookings.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                // Optionally show the error
                // lblMessage.Text = "Error deleting booking: " + ex.Message;
            }
        }

        BindGridView();
    }
}
