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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateAllUsersGridView();
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