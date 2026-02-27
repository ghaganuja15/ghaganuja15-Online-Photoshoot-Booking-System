using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialization code if needed
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        if (!string.IsNullOrEmpty(username))
        {
            User user = GetUserByUsername(username);

            if (user != null)
            {
                // Bind user data to the controls
                txtName.Text = user.Name;
                txtAddress.Text = user.Address;
                txtContact.Text = user.Contact;
                txtEmail.Text = user.Email;

                // Store the UserId in session state
                Session["CurrentUserId"] = user.UserId;

                lblMessage.Text = ""; // Clear any previous messages
            }
            else
            {
                lblMessage.Text = "User not found.";
                ClearFields();
            }
        }
        else
        {
            lblMessage.Text = "Please enter a username.";
            ClearFields();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Retrieve the UserId from session state
        if (Session["CurrentUserId"] == null)
        {
            lblMessage.Text = "Please search for a user first.";
            return;
        }

        int userId = (int)Session["CurrentUserId"];
        string oldPassword = txtOldPassword.Text.Trim();
        string newPassword = txtNewPassword.Text.Trim();
        string name = txtName.Text.Trim();
        string address = txtAddress.Text.Trim();
        string contact = txtContact.Text.Trim();
        string email = txtEmail.Text.Trim();

        // Validate old password
        if (ValidateOldPassword(userId, oldPassword))
        {
            // Update user information
            if (UpdateUser(userId, name, address, contact, email, newPassword))
            {
                lblMessage.Text = "User information updated successfully.";
            }
            else
            {
                lblMessage.Text = "Failed to update user information.";
            }
        }
        else
        {
            lblMessage.Text = "Old password is incorrect.";
        }
    }



    private bool ValidateOldPassword(int userId, string oldPassword)
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Password FROM Users WHERE UserId = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();
            string dbPassword = (string)command.ExecuteScalar();
            return dbPassword == oldPassword; // Compare old password with the one in the database
        }
    }

    private bool UpdateUser(int userId, string name, string address, string contact, string email, string newPassword)
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Users SET Name = @Name, Address = @Address, Contact = @Contact, Email = @Email, Password = @Password WHERE UserId = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Contact", contact);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", newPassword);
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0; // Return true if the update was successful
        }
    }

    private User GetUserByUsername(string username)
    {
        User user = null;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rutik\\source\\repos\\Photoshoot\\Photoshoot\\App_Data\\Database.mdf;Integrated Security=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT UserId, Name, Address, Contact, Email, Password FROM Users WHERE Name = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                user = new User
                {
                    UserId = (int)reader["UserId"],
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                    Contact = reader["Contact"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }
        }
        return user;
    }

    private void ClearFields()
    {
        txtName.Text = "";
        txtAddress.Text = "";
        txtContact.Text = "";
        txtEmail.Text = "";
        txtOldPassword.Text = "";
        txtNewPassword.Text = "";
    }
}
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
}


   