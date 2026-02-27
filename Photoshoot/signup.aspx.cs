using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string address = txtAddress.Text.Trim();
        string contact = txtContact.Text.Trim();
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Replace with your actual database connection string
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO Users (Name, Address, Contact, Email, Password) VALUES (@Name, @Address, @Contact, @Email, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        Response.Write("<script>alert('Registration successful!');</script>");
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}