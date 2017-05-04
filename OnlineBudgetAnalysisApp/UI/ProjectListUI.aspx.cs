using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ProjectListUI : System.Web.UI.Page
    {
        readonly ProjectManager _aProjectManager=new ProjectManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateProjectListGridView();
        }

        private void PopulateProjectListGridView()
        {
            List<Projects> projects = _aProjectManager.GetAllProjectLists();

            prjctListsGridView.DataSource = projects;
            prjctListsGridView.DataBind();


        }
    }
}