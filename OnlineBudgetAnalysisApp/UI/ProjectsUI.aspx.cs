﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ProjectsUI : System.Web.UI.Page
    {
        Projects _aProjects=new Projects();
        ProjectManager _aProjectManager=new ProjectManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            msgLabel.Text=String.Empty;

            _aProjects.ProjectName = txtProjectName.Text;
            _aProjects.ProjectHead = txtProjectHead.Text;
            _aProjects.Description = CKEditorControl.Text;

            string message = _aProjectManager.CreateProject(_aProjects);
            msgLabel.Text = message;
        }
    }
}