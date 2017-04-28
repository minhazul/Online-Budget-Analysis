using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;

namespace OnlineBudgetAnalysisApp
{
    public partial class ResetPasswordUi : System.Web.UI.Page
    {
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            msgLabel.Text=String.Empty;
            string userName=null;
            string email = null;
            string password = null;
            if ((!string.IsNullOrEmpty(Request.QueryString["UserID"])) &
                (!string.IsNullOrEmpty(Request.QueryString["EmailId"])))
            {
                userName = Request.QueryString["UserID"];
                email = Request.QueryString["EmailId"];
                password = txtPassword.Value;
            }
            int rowAffected = _aUsersManager.ResetPassword(userName,email,password);

            if (rowAffected > 0)
            {
                msgLabel.Text = "Your Password has been reset. You can <a href='http://localhost:9429/UI/LoginUI.aspx'>Login</a> now";
            }
            else
            {
                msgLabel.Text = "Password reset failed. Please try again";
            }
        }
    }
}