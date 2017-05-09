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
    public partial class ProjectListUI : System.Web.UI.Page
    {
        private string userName;
        UsersManager _aUsersManager=new UsersManager();
        ProjectManager _aProjectManager=new ProjectManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Session["UserName"].ToString();
            PopulateProjectListGridViewi();
        }

        private void PopulateProjectListGridViewi()
        {
            string fullName = _aUsersManager.GetFullName(userName);

            //List<Projects> aProjects = new List<Projects>();
            //aProjects = _aProjectManager.GetAllProjectLists();

            List<ProjectListShow> aProjectListShows=new List<ProjectListShow>();
            aProjectListShows = _aProjectManager.GetAllProjectListsWithProjectHeadName();

            if (aProjectListShows.Count == 0)
            {
                Response.Write("Project list is empty");
            }
            else
            {
                msgFullName.Text = fullName;
                prjctListGridview.DataSource = aProjectListShows;
                prjctListGridview.DataBind();
            }           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUI.aspx");
        }
    }
}