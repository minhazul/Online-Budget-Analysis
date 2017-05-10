using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class PendingUserManager
    {
        PendingUserGateway _aPendingUserGateway=new PendingUserGateway();
        public List<PendingUsers> GetPendingUsersList()
        {
            return _aPendingUserGateway.GetPendingUsersList();
        }

        public void ApproveUserById(int userId)
        {
            _aPendingUserGateway.ApproveUserById(userId);
        }

        public void DeleteUserById(int userId)
        {
            _aPendingUserGateway.DeleteUserById(userId);
        }
    }
}