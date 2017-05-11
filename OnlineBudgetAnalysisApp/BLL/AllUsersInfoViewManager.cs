using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.UI;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class AllUsersInfoViewManager
    {
        AllUsersInfoViewGateway _allUsersInfoViewGateway=new AllUsersInfoViewGateway();
        public List<AllUsersInfo> GetAllUsersInfo()
        {
            return _allUsersInfoViewGateway.GetAllUsersInfo();
        }
    }
}