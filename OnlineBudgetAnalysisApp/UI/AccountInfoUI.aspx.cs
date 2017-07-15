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
    public partial class AccountInfoUI : System.Web.UI.Page
    {
        Users aUsers = new Users();
        private string userName;
        
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            userName = Session["UserName"].ToString();
            //userName = "minhaz-abir";
            
            if (IsPostBack)
            {
                txtUserName.ReadOnly = false;
                txtFullName.ReadOnly = false;
                txtEmail.ReadOnly = false;
                btnEdit.Visible = false;
                passLabel.Visible = true;
                txtPassword.Visible = true;
                btnSave.Visible = true;
                //btnCancelPass.Visible = true;

            }
            else
            {
                GenerateInformation(userName);
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void GenerateInformation(string userName)
        {
            
            aUsers = _aUsersManager.GetUserInformation(userName);
            if (aUsers == null)
            {
                msgLabel.Text = "Error occured. Please reload the page and try again";
            }
            if (aUsers != null)
            {
                txtUserName.Text = aUsers.UserName;
                txtFullName.Text = aUsers.FullName;
                txtEmail.Text = aUsers.Email;
                
                txtLastLoginDate.Text = aUsers.LastLoginDate.ToString();
            }
        }        

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string password = _aUsersManager.GetUserPassword(userName);
            if (txtPassword.Text == password)
            {
                aUsers=new Users();
                aUsers.UserName = txtUserName.Text;
                aUsers.FullName = txtFullName.Text;
                aUsers.Email = txtEmail.Text;

                string message = null;
                if (aUsers != null)
                {
                    message = _aUsersManager.UpdateUserInfo(userName, password, aUsers);
                    msgLabel.Text = message;
                }

            }
            else
            {
                msgLabel.Text = "Password doesn't match";
            }
        }

        //protected void btnCancelPass_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("AccountInfoUI.aspx");
        //}
    }
}