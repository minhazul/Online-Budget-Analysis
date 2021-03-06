﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class UsersGateway:Gateway
    {
        public int RegisterUsers(Users aUser)
        {

            Query = "insert into Users(UserName,FullName,Designationid,Email,Password,RoleId,Registration_Date) values('" + aUser.UserName + "','" +
                    aUser.FullName + "','"+aUser.DesignationId+"','" + aUser.Email + "','" + aUser.Password + "','"+aUser.RoleId+"','"+DateTime.Now+"')";
            Command=new SqlCommand(Query,Connection);
            
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
        }

        public bool IsUserName(string userName)
        {
            bool isExists=false;
            Query = "SELECT * FROM Users WHERE UserName=@UserName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                isExists = true;
            }
            Reader.Close();
            Connection.Close();
            return isExists;
        }

        public bool IsEmailExists(string email)
        {
            bool isExists = false;
            Query = "SELECT * FROM Users WHERE Email=@Email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                isExists = true;
            }
            Reader.Close();
            Connection.Close();
            return isExists;
        }

        public string FetchUserId(string emailId)
        {
            string UserName = null;
            Query = "SELECT UserName FROM Users WHERE Email=@EmailId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("EmailId", SqlDbType.VarChar);
            Command.Parameters["EmailId"].Value = emailId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    UserName = Reader["UserName"].ToString();
                }
            }
            
            Reader.Close();
            Connection.Close();
            return UserName;
        }

        public int DropData(string userName, string email)
        {
            
            Query = "DELETE FROM Users WHERE UserName=@UserName and Email=@EmailId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("EmailId", SqlDbType.VarChar);
            Command.Parameters["EmailId"].Value = email;
            Connection.Open();
            int rowAffected=Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool Login(string userName, string password)
        {
            bool isLogin = false;
            Query = "SELECT * FROM Users WHERE UserName=@UserName and Password=@Password and Is_Approved=@Is_Approved";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = password;
            Command.Parameters.Add("Is_Approved", SqlDbType.Bit);
            Command.Parameters["Is_Approved"].Value = true;
            
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    isLogin = true;
                }
            }

            Reader.Close();
            Connection.Close();            
            return isLogin;
        }

        public void UpdateLastLoginDate(string userName, string password)
        {
            Query = "UPDATE Users SET LastLoginDate=@LastLoginDate WHERE UserName=@UserName and Password=@Password";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("LastLoginDate", SqlDbType.DateTime);
            Command.Parameters["LastLoginDate"].Value = DateTime.Now;
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = password;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        public int ResetPassword(string userName, string email, string password)
        {
            Query = "UPDATE Users SET Password=@Password WHERE UserName=@UserName and Email=@EmailId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = password;
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("EmailId", SqlDbType.VarChar);
            Command.Parameters["EmailId"].Value = email;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int GetRoleId(string roleName)
        {
            int roleId = 0;
            Query = "SELECT * FROM tblRole WHERE RoleName=@RoleName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("RoleName", SqlDbType.VarChar);
            Command.Parameters["RoleName"].Value = roleName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    roleId = Convert.ToInt32(Reader["Roleid"]);
                }
            }

            Reader.Close();
            Connection.Close();
            return roleId;
        }

        public string GetRoleName(int roleId)
        {
            string roleName = null;
            Query = "SELECT * FROM tblRole WHERE Roleid=@RoleId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("RoleId", SqlDbType.Int);
            Command.Parameters["RoleId"].Value = roleId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    roleName = Reader["RoleName"].ToString();
                }
            }

            Reader.Close();
            Connection.Close();
            return roleName;
        }

        public int GetUserRoleId(string userName)
        {
            int roleId = 0;
            Query = "SELECT * FROM Users WHERE UserName=@UserName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    roleId = Convert.ToInt32(Reader["Roleid"]);
                }
            }

            Reader.Close();
            Connection.Close();
            return roleId;
        }

        public string FindOldPass(string userName)
        {
            string pass = null;
            Query = "SELECT * FROM Users WHERE UserName=@UserName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    pass = Reader["Password"].ToString();
                }
            }

            Reader.Close();
            Connection.Close();
            return pass;
        }

        public int ChangePassword(string userName, string findOldPass, string newPass)
        {
            Query = "UPDATE Users SET Password=@NewPassword WHERE UserName=@UserName and Password=@OldPassword";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("NewPassword", SqlDbType.VarChar);
            Command.Parameters["NewPassword"].Value = newPass;
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("OldPassword", SqlDbType.VarChar);
            Command.Parameters["OldPassword"].Value = findOldPass;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public Users GetUserInformation(string userName)
        {
            Query = "SELECT * FROM Users WHERE UserName=@UserName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;

            Users aUsers=new Users();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    aUsers.UserName = Reader["UserName"].ToString();
                    aUsers.FullName = Reader["FullName"].ToString();
                    aUsers.Email = Reader["Email"].ToString();
                    aUsers.Password = Reader["Password"].ToString();
                    aUsers.LastLoginDate = Convert.ToDateTime(Reader["LastLoginDate"]);
                }
            }
            
            Reader.Close();
            Connection.Close();
            return aUsers;
        }

        public int UpdateUserInfo(string userName, string password, Users aUsers)
        {
            Query = "UPDATE Users SET UserName=@UserName,FullName=@FullName,Email=@Email WHERE UserName=@OldUserName and Password=@Password";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = aUsers.UserName;
            Command.Parameters.Add("FullName", SqlDbType.VarChar);
            Command.Parameters["FullName"].Value = aUsers.FullName;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aUsers.Email;
            Command.Parameters.Add("OldUserName", SqlDbType.VarChar);
            Command.Parameters["OldUserName"].Value = userName;
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = password;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public string GetUserPass(string userName)
        {
            string password=null;
            Query = "SELECT Password FROM Users WHERE UserName=@UserName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;

            Users aUsers = new Users();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    password = Reader["Password"].ToString();
                }
            }

            Reader.Close();
            Connection.Close();
            return password;
        }

        public string GetFullName(string userName)
        {

            Query = "SELECT FullName FROM Users WHERE UserName=@UserName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;

            string fullName = null;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                { 
                    fullName = Reader["FullName"].ToString();
                }
            }

            Reader.Close();
            Connection.Close();
            return fullName;
        }

        public List<Users> GetUsersByDesignationId(int designationId)
        {
            Query = "SELECT Id,FullName FROM Users WHERE Designationid=@DesignationId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("DesignationId", SqlDbType.Int);
            Command.Parameters["DesignationId"].Value = designationId;

            List<Users> listUsers=new List<Users>();

            Users bUsers = new Users();
            bUsers.Id = -1;
            bUsers.FullName = "--Select One--";
            listUsers.Add(bUsers);

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Users aUsers=new Users();
                if (Reader.HasRows)
                {
                    aUsers.Id = Convert.ToInt32(Reader["Id"]);
                    aUsers.FullName = Reader["FullName"].ToString();
                }
                listUsers.Add(aUsers);
            }

            Reader.Close();
            Connection.Close();
            return listUsers;
        }

        public bool IsAdminApproved(string userName, string password)
        {
            bool isAdminApproved = false;
            Query = "SELECT * FROM Users WHERE UserName=@UserName and Password=@Password and IsAdmin_Approved=@IsAdmin_Approved";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = password;
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = true;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    isAdminApproved = true;
                }
            }

            Reader.Close();
            Connection.Close();
            return isAdminApproved;
        }

        public bool IsBlockedByAdmin(string userName, string password)
        {
            bool isBlockedByAdmin = true;

            Query = "SELECT * FROM Users WHERE UserName=@UserName and Password=@Password and BlockedByAdmin=@BlockedByAdmin";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = password;
            Command.Parameters.Add("BlockedByAdmin", SqlDbType.Bit);
            Command.Parameters["BlockedByAdmin"].Value = false;

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    isBlockedByAdmin = false;
                }
            }

            Reader.Close();
            Connection.Close();

            return isBlockedByAdmin;
        }

        public int GetUserIdByUserName(string userName)
        {
            Query = "Select Id From Users Where UserName=@UserName";

            Command=new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("UserName", SqlDbType.VarChar);
            Command.Parameters["UserName"].Value = userName;

            Connection.Open();

            Reader = Command.ExecuteReader();

            int userId=0;

            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    userId = Convert.ToInt32(Reader["Id"]);
                }
            }

            Reader.Close();
            Connection.Close();

            return userId;
        }
    }
}