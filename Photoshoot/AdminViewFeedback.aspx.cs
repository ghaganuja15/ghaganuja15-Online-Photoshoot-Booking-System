using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminViewFeedback : System.Web.UI.Page
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
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Feedback", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridViewFeedback.DataSource = dt;
                GridViewFeedback.DataBind();
            }
        }
    }

    protected void GridViewFeedback_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int feedbackId = Convert.ToInt32(GridViewFeedback.DataKeys[e.RowIndex].Value);
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Feedback WHERE FeedbackID = @FeedbackID", con))
            {
                cmd.Parameters.AddWithValue("@FeedbackID", feedbackId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        BindGridView();
    }
}
