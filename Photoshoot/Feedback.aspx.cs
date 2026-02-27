using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Feedback (Name, Email, Message, Rating) VALUES (@Name, @Email, @Message, @Rating)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Message", txtMessage.Text);
            cmd.Parameters.AddWithValue("@Rating", ddlRating.SelectedValue);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        lblMessageStatus.Text = "Thank you for your feedback!";
    }
}