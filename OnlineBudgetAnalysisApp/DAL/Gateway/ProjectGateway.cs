using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class ProjectGateway:Gateway
    {
        public int CreateProject(Projects aProjects)
        {
            int rowAffected = 0;
            Query =
                "INSERT INTO Projects(ProjectName,ProjectHeadId,Date,Description) VALUES(@ProjectName,@ProjectHeadId,@Date,@Description)";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("ProjectName", SqlDbType.VarChar);
            Command.Parameters["ProjectName"].Value = aProjects.ProjectName;
            Command.Parameters.Add("ProjectHeadId", SqlDbType.Int);
            Command.Parameters["ProjectHeadId"].Value = aProjects.ProjectHeadId;
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

        public List<Projects> GetAllProjects()
        {
            Query = "SELECT Id,ProjectName FROM Projects Where Status=@Status";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.VarChar);
            Command.Parameters["Status"].Value = "Open";
            
            List<Projects> projects=new List<Projects>();
            Projects aProjects=new Projects();
            aProjects.Id = -3;
            aProjects.ProjectName = "--Select One--";
            projects.Add(aProjects);

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                aProjects=new Projects();
                aProjects.Id = Convert.ToInt32(Reader["Id"]);
                aProjects.ProjectName = Reader["ProjectName"].ToString();

                projects.Add(aProjects);
            }

            Reader.Close();
            Connection.Close();

            return projects;
        }

        public List<Projects> GetAllProjectLists()
        {
            Query = "SELECT * FROM Projects";
            Command = new SqlCommand(Query, Connection);

            List<Projects> projects = new List<Projects>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Projects aProjects = new Projects();
                aProjects.Id = Convert.ToInt32(Reader["Id"]);
                aProjects.ProjectName = Reader["ProjectName"].ToString();
                aProjects.ProjectHeadId = Convert.ToInt32(Reader["ProjectHeadId"]);
                aProjects.Date = Convert.ToDateTime(Reader["Date"]);
                aProjects.Description = Reader["Description"].ToString();
                aProjects.Status = Reader["Status"].ToString();

                projects.Add(aProjects);
            }

            Reader.Close();
            Connection.Close();

            return projects;
        }

        public List<ProjectListShow> GetAllProjectListsWithProjectHeadName()
        {
            Query = "SELECT * FROM ProjectListShow";
            Command = new SqlCommand(Query, Connection);

            List<ProjectListShow> projectListShows=new List<ProjectListShow>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                ProjectListShow aProjectListShow=new ProjectListShow();

                aProjectListShow.Id = Convert.ToInt32(Reader["Id"]);
                aProjectListShow.ProjectName = Reader["ProjectName"].ToString();
                aProjectListShow.ProjectHeadName = Reader["ProjectHeadName"].ToString();
                aProjectListShow.Date = Convert.ToDateTime(Reader["Date"]);
                aProjectListShow.Description = Reader["Description"].ToString();
                aProjectListShow.Status = Reader["Status"].ToString();

                projectListShows.Add(aProjectListShow);
            }

            Reader.Close();
            Connection.Close();

            return projectListShows;
        }

        public int CloseProjectById(int prjctId)
        {
            Query = "Update Projects Set Status=@Status Where Id=@Id";

            Command=new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.VarChar);
            Command.Parameters["Status"].Value = "Closed";
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = prjctId;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public void OpenProjectById(int prjctId)
        {
            Query = "Update Projects Set Status=@Status Where Id=@Id";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.VarChar);
            Command.Parameters["Status"].Value = "Open";
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = prjctId;

            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();
        }
    }
}