using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class DashboardUI : System.Web.UI.Page
    {
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["UserName"].ToString();
            //string userName = "minhaz-abir";
            int roleId = _aUsersManager.GetUserRoleId(userName);
            string roleName = _aUsersManager.GetRoleName(roleId);
            if(roleName!="SuperAdmin")
                Response.Redirect("LoginUI.aspx");
        }
    }
}