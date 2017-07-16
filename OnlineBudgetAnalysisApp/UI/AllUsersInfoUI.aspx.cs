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

            if (allUsersInfos.Count == 1)
            {
                paddingControl.Style.Add("padding-bottom", "250px");
            }
            else if (allUsersInfos.Count == 2)
            {
                paddingControl.Style.Add("padding-bottom", "210px");
            }
            else if (allUsersInfos.Count == 3)
            {
                paddingControl.Style.Add("padding-bottom", "180px");
            }
            else if (allUsersInfos.Count == 4)
            {
                paddingControl.Style.Add("padding-bottom", "140px");
            }
            else if (allUsersInfos.Count == 5)
            {
                paddingControl.Style.Add("padding-bottom", "100px");
            }
            else if (allUsersInfos.Count == 6)
            {
                paddingControl.Style.Add("padding-bottom", "80px");
            }
            else if (allUsersInfos.Count == 7)
            {
                paddingControl.Style.Add("padding-bottom", "40px");
            }
            else if (allUsersInfos.Count > 7)
            {
                paddingControl.Style.Add("padding-bottom", "20px");
            }

            allUsersInfoGridView.DataSource = allUsersInfos;
            allUsersInfoGridView.DataBind();
        }
    }
}