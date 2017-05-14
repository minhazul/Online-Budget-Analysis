using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class UploadActivityUI : System.Web.UI.Page
    {
        UploadActivityManager _activityManager=new UploadActivityManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            if (!IsPostBack)
            {
                PopulateUploadActivityGridView();
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void PopulateUploadActivityGridView()
        {
            List<UploadActivity> uploadActivities=new List<UploadActivity>();
            uploadActivities = _activityManager.GetUploadActivityInfo();

            activityGridView.DataSource = uploadActivities;
            activityGridView.DataBind();
        }
    }
}