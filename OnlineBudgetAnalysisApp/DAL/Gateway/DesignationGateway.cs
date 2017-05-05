using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class DesignationGateway:Gateway
    {
        public List<Designation> GetAllDesignatios()
        {
            Query = "SELECT * FROM tblDesignation";
            Command = new SqlCommand(Query, Connection);

            List<Designation> listsDesignation=new List<Designation>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Designation aDesignation=new Designation();
                aDesignation.Id = Convert.ToInt32(Reader["Id"]);
                aDesignation.DesignationName = Reader["DesignationName"].ToString();

                listsDesignation.Add(aDesignation);
            }

            Reader.Close();
            Connection.Close();

            return listsDesignation;
        }
    }
}