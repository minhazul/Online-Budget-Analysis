using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

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
    }
}