using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.ViewModel;
using OnlineBudgetAnalysisApp.UI;

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


        public string ChangeToNormal(int userId, string changedRole)
        {
            int roleId = _aUsersManager.GetRoleId(changedRole);

            int rowAffected = _aUserAccessControlGateway.ChangeToNormal(userId, roleId);

            if (rowAffected > 0)
            {
                return "Access changed successfully";
            }
            else
            {
                return "Access change failed. Try again";
            }
        }

        public string BlockUserById(int userId)
        {
            int rowAffected = _aUserAccessControlGateway.BlockUserById(userId);

            if (rowAffected > 0)
            {
                return "Selected user is blocked succefully.";
            }               
            else
            {
                return "Blocked process failed";
            }
        }

        public List<AllUsersInfo> GetAllCoAdminsInfo()
        {
            return _aUserAccessControlGateway.GetAllCoAdminsInfo();
        }
    }
}