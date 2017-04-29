using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ChangePasswordUI : System.Web.UI.Page
    {
        private string _userName;
        private string _findOldPass;
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
             //_userName = Session["userName"].ToString();
            _userName = "minhazul-abir";
            _findOldPass = _aUsersManager.FindOldPass(_userName);
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            string collectOldPass = txtOldPass.Value;
            string newPass = txtNewPassword.Value;
            if (collectOldPass == _findOldPass)
            {
                string message = _aUsersManager.ChangePassword(_userName, _findOldPass, newPass);
                msgLabel.Text = message;
            }
            else
            {
                msgLabel.Text = "Old password doesn't match";
            }
        }

        protected void btnCancelPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUI.aspx");
        }
    }
}