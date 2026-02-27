using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if the admin is logged in (optional)
            if (Session["AdminEmail"] == null)
            {
                // Optionally redirect to login page if not logged in
                // Response.Redirect("AdminLogin.aspx");
            }
        }
    }


    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        {
            // Check if the user exists in the database before attempting to remove
            if (UserExistsInDatabase(email) && IsPasswordCorrect(email, password))
            {
                // Remove user from the database
                RemoveUsersFromDatabase(email);
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblMessage.Text = "User not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblMessage.Text = "Please enter your email to sign out.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    private bool UserExistsInDatabase(string email)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string query = "SELECT COUNT(*) FROM Admins WHERE Email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                int userCount = (int)command.ExecuteScalar();

                return userCount > 0;
            }
        }
    }
    private bool IsPasswordCorrect(string email, string password)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string query = "SELECT Password FROM Admins WHERE Email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                string storedPassword = (string)command.ExecuteScalar();

                // Compare the provided password with the stored password
                // Note: In a real-world scenario, you should use hashed passwords and compare the hashes
                return storedPassword == password;
            }
        }
    }
    private void RemoveUsersFromDatabase(string email)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string query = "DELETE FROM Admins WHERE Email = @Email";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // User removed successfully
                }
                else
                {
                    // User not found or already removed
                }
            }
        }
    }
}
