using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;

namespace OnlineBudgetAnalysisApp
{
    public partial class Master : System.Web.UI.MasterPage
    {
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["UserName"].ToString();
            //string userName = "minhaz-abir";
            int roleId = _aUsersManager.GetUserRoleId(userName);
            string roleName = _aUsersManager.GetRoleName(roleId);
            MyMenuControl(roleName);            
        }

        private void MyMenuControl(string roleName)
        {
            if (roleName == "Normal")
            {
                prjctCreateLi.Visible = false;
                prjctAngleDown.Visible = false;
                uploadLi.Visible = false;
            }
            else if (roleName == "CoAdmin")
            {
                prjctCreateLi.Visible = false;
                prjctAngleDown.Visible = false;
            }
            else if (roleName == "SuperAdmin")
            {
                uploadLi.Visible = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Login failed. Please try to relogin');", true);
                Response.Redirect("LoginUI.aspx");
                
            }
        }
    }
}