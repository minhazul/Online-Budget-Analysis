using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class UserAccessControl : System.Web.UI.Page
    {
        UserAccessControlManager _accessControlManager=new UserAccessControlManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            FillNoField();
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void FillNoField()
        {
            int noOfTotalUsers = _accessControlManager.GetNoOfTotalUser();
            txtNoTotalUser.Text = noOfTotalUsers.ToString();

            string roleNameFirst = "CoAdmin";
            int noOfCoAdmins = _accessControlManager.GetNoOfCoAdmins(roleNameFirst);
            txtNoCoAdmin.Text = noOfCoAdmins.ToString();

            string roleNameSecond = "Normal";
            int noOfNormalUsers = _accessControlManager.GetNoOfNormalUser(roleNameSecond);
            txtNoNormal.Text = noOfNormalUsers.ToString();

            int noOfPendingUsers = _accessControlManager.GetNoOfPendingUsers();
            txtNoPendingUsers.Text = noOfPendingUsers.ToString();
        }


        protected void btnAllUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllUsersInfoUI.aspx");
        }

        protected void btnCoAdminUserAccess_Click(object sender, EventArgs e)
        {
            Response.Redirect("CoAdminUserAccessUI.aspx");
        }

        protected void btnNormalUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("NormalUserAccessUI.aspx");
        }

        protected void btnBlockedUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlockedUserUI.aspx");
        }

        protected void btnUserActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadActivityUI.aspx");
        }

    }
}