using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Replace with your actual database connection string
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar(); if (count > 0)
                    {
                        // Redirect to the home page upon successful login
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        // Display error message for invalid credentials
                        Response.Write("<script>alert('Invalid email or password.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message if an exception occurs
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}

