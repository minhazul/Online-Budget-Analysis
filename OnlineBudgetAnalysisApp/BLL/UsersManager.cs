using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class UsersManager
    {
        UsersGateway _aUsersGateway = new UsersGateway();

        public string RegisterUser(Users aUsers)
        {
            if (_aUsersGateway.IsEmailExists(aUsers.Email) == true)
            {
                return "This Email Id already exists, please use a different email id";
            }
            else
            {
                if (_aUsersGateway.IsUserName(aUsers.UserName)==true)
                {
                    return "This UserName already exists, Please select a different user name";
                }
                else
                {
                    if (aUsers.UserName.Length > 4)
                    {
                        if (aUsers.Password.Length>5)
                        {
                            int rowAffected = _aUsersGateway.RegisterUsers(aUsers);
                            if (rowAffected > 0)
                            {
                                return "success";
                            }
                            else
                            {
                                return "Registration process failed. Please try again";
                            }
                        }
                        else
                        {
                            return "Password should 6 characters long";
                        }
                    }
                    else
                    {
                        return "UserName should be at least 5 characters long";
                    }
                }
            }
        }

        public string FetchUserId(string emailId)
        {
           string email= _aUsersGateway.FetchUserId(emailId);
            return email;
        }

        public string DropData(string userName, string email)
        {
            if (_aUsersGateway.DropData(userName, email) > 0)
            {
                return "Registration failed. Please try again";
            }
            else
            {
                return "Please try with different username and emailid";
            }
        }

        public bool Login(string userName, string password)
        {
            bool isLogin= _aUsersGateway.Login(userName, password);           
            return isLogin;
        }

        public bool IsUserNameExists(string userName)
        {
            return _aUsersGateway.IsUserName(userName);
        }

        public bool IsEmailExists(string emailid)
        {
            return _aUsersGateway.IsEmailExists(emailid);
        }

        public int ResetPassword(string userName, string email, string password)
        {
            return _aUsersGateway.ResetPassword(userName, email, password);
        }

        public int GetRoleId(string roleName)
        {
            return _aUsersGateway.GetRoleId(roleName);
        }

        public string GetRoleName(int roleId)
        {
            return _aUsersGateway.GetRoleName(roleId);
        }

        public int GetUserRoleId(string userName)
        {
            return _aUsersGateway.GetUserRoleId(userName);
        }

        public string FindOldPass(string userName)
        {
            return _aUsersGateway.FindOldPass(userName);
        }

        public string ChangePassword(string userName, string findOldPass, string newPass)
        {
            int rowAffected = _aUsersGateway.ChangePassword(userName, findOldPass, newPass);
            if (rowAffected > 0)
            {
                return "Password changed successfully";
            }
            else
            {
                return "Password changed failed. Please reload the page page and try again";
            }
        }

        public Users GetUserInformation(string userName)
        {
            return _aUsersGateway.GetUserInformation(userName);
        }

        public string UpdateUserInfo(string userName, string password, Users aUsers)
        {
            int rowAffected = _aUsersGateway.UpdateUserInfo(userName, password, aUsers);
            if (rowAffected > 0)
            {
                return "Account information updated successfully";
            }
            else
            {
                return "Update failed. Please try again";
            }
        }

        public string GetUserPassword(string userName)
        {
            return _aUsersGateway.GetUserPass(userName);
        }

        public string GetFullName(string userName)
        {
            return _aUsersGateway.GetFullName(userName);
        }

        public List<Users> GetUserByDesignationId(int designationId)
        {
            return _aUsersGateway.GetUsersByDesignationId(designationId);
        }

        public bool IsAdminApproved(string userName, string password)
        {
            bool isAdminApproved = _aUsersGateway.IsAdminApproved(userName, password);
            
            return isAdminApproved;
        }

        public bool IsBlockedByAdmin(string userName, string password)
        {
            bool isBlockedByAdmin = _aUsersGateway.IsBlockedByAdmin(userName, password);
            if (!isBlockedByAdmin)
            {
                _aUsersGateway.UpdateLastLoginDate(userName, password);
            }

            return isBlockedByAdmin;
        }
    }
}