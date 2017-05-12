using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;

namespace OnlineBudgetAnalysisApp
{
    public partial class LoginUI : System.Web.UI.Page
    {
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            string userName = txtUsername.Value;
            string password = txtPassword.Value;
            bool isLogin = _aUsersManager.Login(userName,password);
            if (isLogin)
            {
                bool isAdminApproved = _aUsersManager.IsAdminApproved(userName, password);
                if (isAdminApproved)
                {
                    bool blockedByAdmin = _aUsersManager.IsBlockedByAdmin(userName, password);
                    if (!blockedByAdmin)
                    {
                        Session["UserName"] = userName;
                        Response.Redirect("HomeUI.aspx");
                    }
                    else
                    {
                        msgLabel.Text = "Access denied by Admin";
                    }
                    
                }
                else
                {
                    msgLabel.Text = "You are not approved by Admin yet";
                }
            }
            else
            {
                msgLabel.Text = "UserName or Password doesn't match";
            }
            
        }
    }
}