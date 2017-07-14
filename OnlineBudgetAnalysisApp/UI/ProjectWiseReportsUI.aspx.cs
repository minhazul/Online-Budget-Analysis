using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ProjectWiseReportsUI : System.Web.UI.Page
    {
        string userName;
        ProjectManager _aProjectManager = new ProjectManager();
        UsersManager _aUsersManager = new UsersManager();
        ReportManager _aReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            if (!IsPostBack)
            {
                userName = Session["UserName"].ToString();
                string fullName = _aUsersManager.GetFullName(userName);
                msgFullName.Text = fullName;
                PopulateProjectDropdown();
            }
        }


        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void PopulateProjectDropdown()
        {
            List<Projects> projects = new List<Projects>();
            projects = _aProjectManager.GetAllProjects();

            dropDownProjectList.DataSource = projects;
            dropDownProjectList.DataTextField = "ProjectName";
            dropDownProjectList.DataValueField = "Id";
            dropDownProjectList.DataBind();

            //if (dropDownProjectList.Items.Count > 1)
            //{
            //    dropDownProjectList.Enabled = true;
            //}
            //else
            //    dropDownProjectList.Enabled = false;
        }

        protected void dropDownProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projectId = Convert.ToInt32(dropDownProjectList.SelectedValue);
            PopulateProjectWiseReportGridView(projectId);
        }

        private void PopulateProjectWiseReportGridView(int projectId)
        {
            List<Report> projectWiseReports = new List<Report>();
            projectWiseReports = _aReportManager.GetProjectWiseReport(projectId);

            prjctWiseRepotGridView.DataSource = projectWiseReports;
            prjctWiseRepotGridView.DataBind();
        }
    }
}