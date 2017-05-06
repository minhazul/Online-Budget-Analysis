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
    public partial class ProjectsUI : System.Web.UI.Page
    {
        Projects _aProjects=new Projects();
        ProjectManager _aProjectManager=new ProjectManager();
        DesignationManager _aDesignationManager=new DesignationManager();
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDesignationDropDown();
            }
        }

        protected void dropDownDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropDownProjectHead.AppendDataBoundItems = true;

            int designationId = Convert.ToInt32(dropDownDesignation.SelectedValue);
            List<Users> listUsers=new List<Users>();
            listUsers = _aUsersManager.GetUserByDesignationId(designationId);

            dropDownProjectHead.Items.Clear();
            dropDownProjectHead.Items.Add(new ListItem("--Select One--", ""));

            dropDownProjectHead.DataSource = listUsers;
            dropDownProjectHead.DataTextField = "FullName";
            dropDownProjectHead.DataValueField = "Id";
            dropDownProjectHead.DataBind();

            if (dropDownProjectHead.Items.Count > 1)
            {
                dropDownProjectHead.Enabled = true;
            }
            else
            {
                dropDownProjectHead.Enabled = false;
            }

        }

        private void PopulateDesignationDropDown()
        {
            List<Designation> listDesignations=new List<Designation>();
            listDesignations = _aDesignationManager.GetAllDesignation();

            dropDownDesignation.DataSource = listDesignations;
            dropDownDesignation.DataTextField = "DesignationName";
            dropDownDesignation.DataValueField = "Id";
            dropDownDesignation.DataBind();

            if (dropDownDesignation.Items.Count > 1)
            {
                dropDownDesignation.Enabled = true;
            }
            else
            {
                dropDownDesignation.Enabled = false;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            msgLabel.Text=String.Empty;

            _aProjects.ProjectName = txtProjectName.Text;
            _aProjects.ProjectHeadId = Convert.ToInt32(dropDownProjectHead.SelectedValue);
            _aProjects.Description = CKEditorControl.Text;

            string message = _aProjectManager.CreateProject(_aProjects);
            msgLabel.Text = message;
        }
    }
}