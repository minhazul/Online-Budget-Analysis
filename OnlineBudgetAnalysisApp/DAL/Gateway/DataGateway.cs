using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class DataGateway:Gateway
    {
        public int ClearProductInfoData()
        {
            Query = "Delete  From ProductInfo";

            Command=new SqlCommand(Query,Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}