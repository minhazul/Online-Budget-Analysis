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
                                return "Success";
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
    }
}