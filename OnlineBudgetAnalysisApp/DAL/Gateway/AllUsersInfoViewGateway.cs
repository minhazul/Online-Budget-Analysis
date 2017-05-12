using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.UI;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class AllUsersInfoViewGateway:Gateway
    {
        public List<AllUsersInfo> GetAllUsersInfo()
        {
            Query = "Select Id, UserName, FullName, Email, Designation, Role, RegistrationDate, LastLoginDate From UsersInfo";

            Command=new SqlCommand(Query,Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<AllUsersInfo> allUsersInfos=new List<AllUsersInfo>();

            while (Reader.Read())
            {
                AllUsersInfo allUsersInfo = new AllUsersInfo();

                allUsersInfo.Id = Convert.ToInt32(Reader["Id"]);
                allUsersInfo.UserName = Reader["UserName"].ToString();
                allUsersInfo.FullName = Reader["FullName"].ToString();
                allUsersInfo.Email = Reader["Email"].ToString();
                allUsersInfo.Designation = Reader["Designation"].ToString();
                allUsersInfo.Role = Reader["Role"].ToString();
                allUsersInfo.RegistrationDate = Reader["RegistrationDate"].ToString();
                allUsersInfo.LastLoginDate = Reader["LastLoginDate"].ToString();                

                allUsersInfos.Add(allUsersInfo);
            }

            Reader.Close();
            Connection.Close();

            return allUsersInfos;
        }
    }
}