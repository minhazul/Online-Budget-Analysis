using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class UserAccessControlManager
    {
        UserAccessControlGateway _aUserAccessControlGateway=new UserAccessControlGateway();
        UsersManager _aUsersManager=new UsersManager();

        public int GetNoOfTotalUser()
        {
            return _aUserAccessControlGateway.GetNoOfTotalUser();
        }


        public int GetNoOfCoAdmins(string roleNameFirst)
        {
            int roleId = _aUsersManager.GetRoleId(roleNameFirst);

            return _aUserAccessControlGateway.GetNoOfCoAdmins(roleId);
        }

        public int GetNoOfNormalUser(string roleNameSecond)
        {
            int roleId = _aUsersManager.GetRoleId(roleNameSecond);

            return _aUserAccessControlGateway.GetNoOfNormalUser(roleId);
        }

        public int GetNoOfPendingUsers()
        {
            return _aUserAccessControlGateway.GetNoOfPendingUsers();
        }
    }
}