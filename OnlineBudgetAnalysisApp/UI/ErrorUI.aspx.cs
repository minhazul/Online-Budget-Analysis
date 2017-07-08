using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ErrorUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUI.aspx");
        }
    }
}