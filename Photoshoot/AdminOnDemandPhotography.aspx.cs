using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminOnDemandPhotography : System.Web.UI.Page
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();  // Load data into the GridView when the page first loads
        }
    }

    // Method to bind data to the GridView
    private void BindGrid()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM PhotographyServices";  // Query to fetch all photography services

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); da.Fill(dt);  // Fill the DataTable with the results
                GridViewServices.DataSource = dt;
                GridViewServices.DataBind();  // Bind data to the GridView
            }
        }
    }

    protected void btnAddService_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO PhotographyServices (ServiceName, Description, ImageURL, Price) VALUES (@ServiceName, @Description, @ImageURL, @Price)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@ServiceName", txtServiceName.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@ImageURL", txtImageURL.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));

                con.Open();
                cmd.ExecuteNonQuery();  // Execute the query to add the new service
            }
        } // Clear form inputs after adding
        txtServiceName.Text = "";
        txtDescription.Text = "";
        txtImageURL.Text = "";
        txtPrice.Text = "";

        // Rebind the GridView to show the newly added service
        BindGrid();
    }// Handle the "Delete" button click in the GridView
    protected void GridViewServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int serviceID = Convert.ToInt32(GridViewServices.DataKeys[e.RowIndex].Value);  // Get ServiceID of the service to delete

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM PhotographyServices WHERE ServiceID = @ServiceID";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@ServiceID", serviceID);

                con.Open();
                cmd.ExecuteNonQuery();  // Execute the query to delete the service
            }
        }// Rebind the GridView after deletion
        BindGrid();
    }
}
