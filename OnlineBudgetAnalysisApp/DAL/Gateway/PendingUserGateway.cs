using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class PendingUserGateway:Gateway
    {
        public List<PendingUsers> GetPendingUsersList()
        {
            Query = "Select Id,FullName,DesignationName,Email, CONVERT(CHAR(11), Registration_Date, 106) as Registration_Date from PendingUsers where Is_Approved=@Is_Approved and IsAdmin_Approved=@IsAdmin_Approved";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Is_Approved", SqlDbType.Bit);
            Command.Parameters["Is_Approved"].Value = true;
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = false;

            Connection.Open();
            Reader = Command.ExecuteReader();

            List<PendingUsers> pendingUsers=new List<PendingUsers>();

            while (Reader.Read())
            {
                PendingUsers aPendingUsers=new PendingUsers();

                aPendingUsers.Id = Convert.ToInt32(Reader["Id"]);
                aPendingUsers.FullName = Reader["FullName"].ToString();
                aPendingUsers.DesignationName = Reader["DesignationName"].ToString();
                aPendingUsers.Email = Reader["Email"].ToString();
                aPendingUsers.Registration_Date = Reader["Registration_Date"].ToString();

                pendingUsers.Add(aPendingUsers);
            }

            Reader.Close();
            Connection.Close();

            return pendingUsers;
        }

        public void ApproveUserById(int userId)
        {
            Query = "Update Users set IsAdmin_Approved=@IsAdmin_Approved Where Id=@Id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = true;
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