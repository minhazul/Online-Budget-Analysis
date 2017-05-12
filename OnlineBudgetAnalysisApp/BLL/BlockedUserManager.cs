using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class BlockedUserManager
    {
        BlockedUserGateway _aBlockedUserGateway=new BlockedUserGateway();
        public List<BlockedUserInfo> GetAllBlockedUsers()
        {
            return _aBlockedUserGateway.GetAllBlockedUsers();
        }

        public void AllowBlockedUserById(int userId)
        {
            _aBlockedUserGateway.AllowBlockedUsersById(userId);
        }

        public void DeleteUserById(int userId)
        {
            _aBlockedUserGateway.DeleteUserById(userId);
        }
    }
}