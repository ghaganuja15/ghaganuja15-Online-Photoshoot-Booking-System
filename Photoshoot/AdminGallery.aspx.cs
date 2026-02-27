using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminGallery : System.Web.UI.Page
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
            string query = "SELECT * FROM GalleryImages";  // Query to fetch all gallery images

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);  // Fill the DataTable with the results
                GridViewGallery.DataSource = dt;
                GridViewGallery.DataBind();  // Bind data to the GridView
            }
        }
    }

    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO GalleryImages (ImagePath, Category) VALUES (@ImagePath, @Category)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@ImagePath", txtImagePath.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);

                con.Open();
                cmd.ExecuteNonQuery();  // Execute the query to add the new image
            }
        }// Clear form inputs after adding
        txtImagePath.Text = "";
        txtCategory.Text = "";

        // Rebind the GridView to show the newly added image
        BindGrid();
    }

    // Handle the "Delete" button click in the GridView
    protected void GridViewGallery_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int imageId = Convert.ToInt32(GridViewGallery.DataKeys[e.RowIndex].Value);  // Get Id of the image to delete

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM GalleryImages WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Add parameter to prevent SQL injection
                cmd.Parameters.AddWithValue("@Id", imageId);

                con.Open();
                cmd.ExecuteNonQuery();  // Execute the query to delete the image
            }
        }

        // Rebind the GridView after deletion
        BindGrid();
    }
}
