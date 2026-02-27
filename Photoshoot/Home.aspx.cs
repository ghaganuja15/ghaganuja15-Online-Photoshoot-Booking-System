using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPhotoShoots();
        }
    }

    private void BindPhotoShoots()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT Title, Description, ImagePath FROM PhotoShoots";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rptPhotoshoots.DataSource = dt;
            rptPhotoshoots.DataBind();
        }
    }


    protected void rptPhotoshoots_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        // Handle the button click or other commands here
        if (e.CommandName == "BookNow")
        {
            // Redirect to the booking page
            Response.Redirect("BookNow.aspx");
        }
    }
}

