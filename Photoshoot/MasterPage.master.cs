using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkOnDemand_Click(object sender, EventArgs e)
    {
        // Redirect or handle the click event
        Response.Redirect("OnDemandPhotography.aspx");
    }

    protected void lnkPersonal_Click(object sender, EventArgs e)
    {
        // Redirect or handle the click event
        Response.Redirect("PersonalPhotography.aspx");
    }

    protected void lnkOpenEvents_Click(object sender, EventArgs e)
    {
        // Redirect or handle the click event
        Response.Redirect("OpenEventsPhotography.aspx");
    }

}
