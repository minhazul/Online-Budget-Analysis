using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class EmailGateway:Gateway
    {
        public Email GetEmailAndPass()
        {
            Query = "Select * from ApplicationEmail Where Status=@Status";

            Command=new SqlCommand(Query,Connection);            

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.Bit);
            Command.Parameters["Status"].Value = true;

            Connection.Open();
            Reader = Command.ExecuteReader();

            Email aEmail=new Email();

            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    aEmail.Id = Convert.ToInt32(Reader["Id"]);
                    aEmail.EmailName = Reader["Email"].ToString();
                    aEmail.Password = Reader["Password"].ToString();
                    aEmail.Status = Convert.ToBoolean(Reader["Status"]);
                }
            }

            Reader.Close();
            Connection.Close();

            return aEmail;
        }
    }
}