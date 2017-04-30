using System;
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

            Query = "insert into Users(UserName,FullName,Email,Password,RoleId) values('" + aUser.UserName + "','" +
                    aUser.FullName + "','" + aUser.Email + "','" + aUser.Password + "','"+aUser.RoleId+"')";
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
            Command.Parameters.Add("Is_Approved", SqlDbType.VarChar);
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
    }
}