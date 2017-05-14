using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class ProjectManager
    {
        ProjectGateway _aProjectGateway=new ProjectGateway();
        public string CreateProject(Projects aProjects)
        {
            
            if (_aProjectGateway.IsExists(aProjects.ProjectName))
            {
                return "The project name already exists. Please choose a different name";
            }
            else
            {
                int rowAffected = _aProjectGateway.CreateProject(aProjects);
                if (rowAffected > 0)
                {
                    return "Successfully created";
                }
                else
                {
                    return "Failed to create. Please try again";
                }
            }
            
        }

        public List<Projects> GetAllProjects()
        {
            return _aProjectGateway.GetAllProjects();
        }

        public List<Projects> GetAllProjectLists()
        {
            return _aProjectGateway.GetAllProjectLists();
        }

        public List<ProjectListShow> GetAllProjectListsWithProjectHeadName()
        {
            return _aProjectGateway.GetAllProjectListsWithProjectHeadName();
        }

        public string CloseProjectById(int prjctId)
        {
            int rowAffected = _aProjectGateway.CloseProjectById(prjctId);

            if (rowAffected > 0)
            {
                return "Selected project closed successfully";
            }
            else
            {
                return "Failed to close the project";
            }
        }

        public void OpenProjectIdById(int prjctId)
        {
            _aProjectGateway.OpenProjectById(prjctId);
        }
    }
}