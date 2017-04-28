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
        //    Query = "INSERT INTO Users (UserName,FullName,Email,Password) VALUES (@UserName, @FullName, @Email, @Password";
        //    Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.Clear();
        //    Command.Parameters.Add("UserName", SqlDbType.VarChar);
        //    Command.Parameters["UserName"].Value = aUser.UserName;
        //    Command.Parameters.Add("FullName", SqlDbType.VarChar);
        //    Command.Parameters["FullName"].Value = aUser.FullName;
        //    Command.Parameters.Add("Email", SqlDbType.VarChar);
        //    Command.Parameters["Email"].Value = aUser.Email;
        //    Command.Parameters.Add("Password", SqlDbType.VarChar);
        //    Command.Parameters["Password"].Value = aUser.Password;

            Query = "insert into Users(UserName,FullName,Email,Password) values('" + aUser.UserName + "','" +
                    aUser.FullName + "','" + aUser.Email + "','" + aUser.Password + "')";
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
    }
}