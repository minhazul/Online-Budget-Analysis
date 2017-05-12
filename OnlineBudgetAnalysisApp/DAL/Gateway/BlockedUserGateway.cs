using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class BlockedUserGateway:Gateway
    {
        public List<BlockedUserInfo> GetAllBlockedUsers()
        {
            Query = "Select * From BlockedUserInfo";

            Command=new SqlCommand(Query,Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<BlockedUserInfo> blockedUserInfos=new List<BlockedUserInfo>();

            while (Reader.Read())
            {
                BlockedUserInfo aBlockedUserInfo=new BlockedUserInfo();

                aBlockedUserInfo.Id = Convert.ToInt32(Reader["Id"]);
                aBlockedUserInfo.UserName = Reader["UserName"].ToString();
                aBlockedUserInfo.FullName = Reader["FullName"].ToString();
                aBlockedUserInfo.Email = Reader["Email"].ToString();
                aBlockedUserInfo.Designation = Reader["Designation"].ToString();
                aBlockedUserInfo.Role = Reader["Role"].ToString();
                aBlockedUserInfo.RegistrationDate = Reader["RegistrationDate"].ToString();
                aBlockedUserInfo.LastLoginDate = Reader["LastLoginDate"].ToString();

                blockedUserInfos.Add(aBlockedUserInfo);
            }

            Reader.Close();
            Connection.Close();

            return blockedUserInfos;
        }

        public void AllowBlockedUsersById(int userId)
        {
            Query = "Update Users set BlockedByAdmin=@BlockedByAdmin Where Id=@Id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("BlockedByAdmin", SqlDbType.Bit);
            Command.Parameters["BlockedByAdmin"].Value = false;
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = userId;

            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();
        }

        public void DeleteUserById(int userId)
        {
            Query = "Delete From Users Where Id=@Id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = userId;

            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();
        }
    }
}