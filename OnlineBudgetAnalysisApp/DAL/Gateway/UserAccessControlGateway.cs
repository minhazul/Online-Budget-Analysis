using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class UserAccessControlGateway:Gateway
    {
        public int GetNoOfTotalUser()
        {
            Query = "Select COUNT(Id) as NoOfTotalUsers From Users Where Is_Approved=@Is_Approved and IsAdmin_Approved=@IsAdmin_Approved";

            Command=new SqlCommand(Query,Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("Is_Approved", SqlDbType.Bit);
            Command.Parameters["Is_Approved"].Value = true;
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = true;

            int noOfTotalUsers = 0;

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                noOfTotalUsers = Convert.ToInt32(Reader["NoOfTotalUsers"]);
            }

            Connection.Close();

            return noOfTotalUsers;
        }

        public int GetNoOfCoAdmins(int roleId)
        {
            Query = "Select COUNT(Id) as NoOfCoAdmins From Users Where Is_Approved=@Is_Approved and IsAdmin_Approved=@IsAdmin_Approved and RoleId=@RoleId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("Is_Approved", SqlDbType.Bit);
            Command.Parameters["Is_Approved"].Value = true;
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = true;
            Command.Parameters.Add("RoleId", SqlDbType.Int);
            Command.Parameters["RoleId"].Value = roleId;

            int noOfCoAdmins = 0;

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                noOfCoAdmins = Convert.ToInt32(Reader["NoOfCoAdmins"]);
            }

            Connection.Close();

            return noOfCoAdmins;
        }

        public int GetNoOfNormalUser(int roleId)
        {
            Query = "Select COUNT(Id) as NoOfNormalUser From Users Where Is_Approved=@Is_Approved and IsAdmin_Approved=@IsAdmin_Approved and RoleId=@RoleId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("Is_Approved", SqlDbType.Bit);
            Command.Parameters["Is_Approved"].Value = true;
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = true;
            Command.Parameters.Add("RoleId", SqlDbType.Int);
            Command.Parameters["RoleId"].Value = roleId;

            int noOfNormalUsers = 0;

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                noOfNormalUsers = Convert.ToInt32(Reader["NoOfNormalUser"]);
            }

            Connection.Close();

            return noOfNormalUsers;
        }

        public int GetNoOfPendingUsers()
        {
            Query = "Select COUNT(Id) as NoOfPendingUser From Users Where Is_Approved=@Is_Approved and IsAdmin_Approved=@IsAdmin_Approved";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();            

            Command.Parameters.Clear();
            Command.Parameters.Add("Is_Approved", SqlDbType.Bit);
            Command.Parameters["Is_Approved"].Value = true;
            Command.Parameters.Add("IsAdmin_Approved", SqlDbType.Bit);
            Command.Parameters["IsAdmin_Approved"].Value = false;           

            int noOfPendingUsers = 0;

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                noOfPendingUsers = Convert.ToInt32(Reader["NoOfPendingUser"]);
            }

            Connection.Close();

            return noOfPendingUsers;
        }
    }
}