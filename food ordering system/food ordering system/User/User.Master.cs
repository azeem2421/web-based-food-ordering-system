using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace food_ordering_system.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Request.Url.AbsoluteUri.ToString().Contains("Default.aspx"))
            {

                form1.Attributes.Add("class", "sub_page");

            }

            else
            {

                form1.Attributes.Remove("class");

                //Load the control
                Control slideUserControl = (Control)Page.LoadControl("SlideUserControl.ascx");

                //Add the contoller to the panel

                PnlSliderUC.Controls.Add(slideUserControl);

            }

            if (Session["UserId"] != null)
            {

                lbLoginOrLogout.Text = "Logout";

            }
            else
            {
                lbLoginOrLogout.Text = "Login";
            }

        }

        protected void lbLoginOrLogout_Click(object sender, EventArgs e)
        {


            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
        }

        protected void lblRegisterOrProfile_Click(object sender, EventArgs e)
        {

            if (Session["UserId"] != null)
            {
                lblRegisterOrProfile.ToolTip = "User Profile";
                Response.Redirect("Profile.aspx");
            }
            else
            {
                lblRegisterOrProfile.ToolTip = "User Registration";

                Response.Redirect("Registration.aspx");

            }

        }
    }
}