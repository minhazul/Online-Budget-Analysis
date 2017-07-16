using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ProjectListUI : System.Web.UI.Page
    {
        private string userName;
        UsersManager _aUsersManager = new UsersManager();
        ProjectManager _aProjectManager = new ProjectManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            userName = Session["UserName"].ToString();
            PopulateProjectListGridViewi();
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
                Response.Redirect("HomeUI.aspx");
        }

        private void PopulateProjectListGridViewi()
        {
            //string fullName = _aUsersManager.GetFullName(userName);

            //List<Projects> aProjects = new List<Projects>();
            //aProjects = _aProjectManager.GetAllProjectLists();

            List<ProjectListShow> aProjectListShows = new List<ProjectListShow>();
            aProjectListShows = _aProjectManager.GetAllProjectListsWithProjectHeadName();

            if (aProjectListShows.Count == 0)
            {
                msgLists.Text = "Project list is empty";

                paddingControl.Style.Add("padding-bottom","264px");
            }
            else
            {
                //msgFullName.Text = fullName;
                prjctListGridview.DataSource = aProjectListShows;
                prjctListGridview.DataBind();

                if (aProjectListShows.Count==1)
                {
                    paddingControl1.Style.Add("padding-bottom", "128px");
                }
                else if (aProjectListShows.Count == 2)
                {
                    paddingControl1.Style.Add("padding-bottom", "88px");
                }
                else if (aProjectListShows.Count == 3)
                {
                    paddingControl1.Style.Add("padding-bottom", "48px");
                }
                else if (aProjectListShows.Count > 3)
                {
                    paddingControl1.Style.Add("padding-bottom", "20px");
                }             
               
            }
        }
    }
}