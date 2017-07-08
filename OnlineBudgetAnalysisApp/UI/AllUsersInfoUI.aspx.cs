using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class AllUsersInfoUI : System.Web.UI.Page
    {
        AllUsersInfoViewManager _allUsersInfoViewManager=new AllUsersInfoViewManager();
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            AccessControl();

            if (!IsPostBack)
            {
                PopulateAllUsersGridView();
            }
        }

        private void AccessControl()
        {
            string userName = Session["UserName"].ToString();

            int roleId = _aUsersManager.GetUserRoleId(userName);

            string roleName = _aUsersManager.GetRoleName(roleId);

            if (roleName == "CoAdmin" || roleName == "Normal")
            {
                Response.Redirect("ErrorUI.aspx");
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void PopulateAllUsersGridView()
        {
            List<AllUsersInfo> allUsersInfos=new List<AllUsersInfo>();
            allUsersInfos = _allUsersInfoViewManager.GetAllUsersInfo();

            allUsersInfoGridView.DataSource = allUsersInfos;
            allUsersInfoGridView.DataBind();
        }
    }
}