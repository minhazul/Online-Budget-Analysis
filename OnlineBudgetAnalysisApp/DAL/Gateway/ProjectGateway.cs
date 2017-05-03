using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class ProjectGateway:Gateway
    {
        public int CreateProject(Projects aProjects)
        {
            int rowAffected = 0;
            Query =
                "INSERT INTO Projects(ProjectName,ProjectHead,Date,Description) VALUES(@ProjectName,@ProjectHead,@Date,@Description)";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("ProjectName", SqlDbType.VarChar);
            Command.Parameters["ProjectName"].Value = aProjects.ProjectName;
            Command.Parameters.Add("ProjectHead", SqlDbType.VarChar);
            Command.Parameters["ProjectHead"].Value = aProjects.ProjectHead;
            Command.Parameters.Add("Date", SqlDbType.DateTime);
            Command.Parameters["Date"].Value = DateTime.Now;
            Command.Parameters.Add("Description", SqlDbType.NChar);
            Command.Parameters["Description"].Value = aProjects.Description;

            rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsExists(string projectName)
        {
            bool isExists = false;
            Query = "SELECT * FROM Projects WHERE ProjectName=@ProjectName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("ProjectName", SqlDbType.VarChar);
            Command.Parameters["ProjectName"].Value = projectName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    isExists = true;
                }
            }
            
            Reader.Close();
            Connection.Close();
            return isExists;
        }
    }
}