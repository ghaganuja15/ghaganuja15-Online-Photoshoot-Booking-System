using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnDemandPhotography : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindServices();
        }
    }

    private void BindServices()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT ServiceID, ServiceName, Description, ImageURL, Price FROM PhotographyServices";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            rptServices.DataSource = reader;
            rptServices.DataBind();
            conn.Close();
        }
    }


    protected void btnBook_Click(object sender, EventArgs e)
    {
        // Cast the sender to a Button
        Button btn = (Button)sender;

        // Get the ServiceID from the button's CommandArgument
        string serviceID = btn.CommandArgument;

        // Store the selected service in a session
        Session["SelectedServiceID"] = serviceID;

        // Redirect to the booking page
        Response.Redirect("BookNow.aspx");
    }

    protected void rptServices_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}


