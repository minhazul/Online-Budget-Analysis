using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class HomeUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
        }

        private void SessionControl()
        {
            string userName;
            if (Session["UserName"] == null)
            {
                HttpCookie myCookie = Request.Cookies["Login"];
                if (myCookie != null)
                {
                    userName = myCookie["UserName"];
                    Session["UserName"] = userName;
                }
                else
                {
                    Response.Redirect("LoginUI.aspx");
                }
            }

            userName = Session["UserName"].ToString();
        }
    }
}