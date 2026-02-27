using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkOnDemand_Click(object sender, EventArgs e)
    {
        // Redirect or handle the click event
        Response.Redirect("AdminOnDemandPhotography.aspx");
    }

    protected void lnkPersonal_Click(object sender, EventArgs e)
    {
        // Redirect or handle the click event
        Response.Redirect("AdminPersonalPhotography.aspx");
    }

    protected void lnkOpenEvents_Click(object sender, EventArgs e)
    {
        // Redirect or handle the click event
        Response.Redirect("AdminOpenEventsPhotography.aspx");
    }
}
