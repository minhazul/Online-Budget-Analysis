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
    public partial class ProjectAndDataControlUI : System.Web.UI.Page
    {
        ProjectManager _aProjectManager=new ProjectManager();
        DataManager _aDataManager=new DataManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            if (!IsPostBack)
            {
                PopulateProjectsControlGridVIew();                
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void PopulateProjectsControlGridVIew()
        {
            List<ProjectListShow> projectListShows = new List<ProjectListShow>();
            projectListShows = _aProjectManager.GetAllProjectListsWithProjectHeadName();

            if (projectListShows.Count == 0)
            {
                msgPrjctLabel.Text = "The list is empty";
            }

            prjctCntrlGridView.DataSource = projectListShows;
            prjctCntrlGridView.DataBind();
        }

        protected void prjctCntrlGridView_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control ctrl = e.Row.FindControl("openOrCloseDropDownList");

                if (ctrl != null)
                {
                    DropDownList aDropDownList = ctrl as DropDownList;

                    List<OpenOrClose> openOrCloses=new List<OpenOrClose>();

                    for (int i = 0; i < 3; i++)
                    {
                        OpenOrClose aOpenOrClose=new OpenOrClose();

                        if (i == 1)
                        {
                            aOpenOrClose.Id = i;
                            aOpenOrClose.Action = "Open";
                            openOrCloses.Add(aOpenOrClose);
                        }
                        else if (i == 2)
                        {
                            aOpenOrClose.Id = i;
                            aOpenOrClose.Action = "Close";
                            openOrCloses.Add(aOpenOrClose);
                        }
                        else
                        {
                            aOpenOrClose.Id = i;
                            aOpenOrClose.Action = "--Select one--";
                            openOrCloses.Add(aOpenOrClose);
                        }
                    }

                    if (aDropDownList != null)
                    {
                        aDropDownList.DataSource = openOrCloses;
                        aDropDownList.DataTextField = "Action";
                        aDropDownList.DataValueField = "Id";
                        aDropDownList.DataBind();
                    }
                }
            }
        }

        protected void openOrCloseDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList aDropDownList = sender as DropDownList;

            foreach (GridViewRow row in prjctCntrlGridView.Rows)
            {
                Control ctrl = row.FindControl("openOrCloseDropDownList") as DropDownList;

                if (ctrl != null)
                {
                    DropDownList abDropDownList = (DropDownList)ctrl;

                    DataControlFieldCell cell = abDropDownList.Parent as DataControlFieldCell;
                    GridViewRow selectedRow = cell.Parent as GridViewRow;
                    HiddenField selectedHiddenField = selectedRow.FindControl("idHiddenField") as HiddenField;

                    int prjctId = Convert.ToInt32(selectedHiddenField.Value);

                    if (aDropDownList.ClientID == abDropDownList.ClientID)
                    {
                        int selectId = Convert.ToInt32(abDropDownList.SelectedValue);

                        if (selectId == 1)
                        {
                            _aProjectManager.OpenProjectIdById(prjctId);
                            PopulateProjectsControlGridVIew();
                        }
                        else if (selectId == 2)
                        {
                            _aProjectManager.CloseProjectById(prjctId);
                            PopulateProjectsControlGridVIew();
                        }
                        else
                        {
                            msgPrjctLabel.Text = "Please select a valid action from dropdown";
                        }
                    }
                }
            }
        }

        protected void btnClearProductInfo_Click(object sender, EventArgs e)
        {
            msgClearProductInfoLabel.Text = _aDataManager.ClearProductInfoData();
        }

        protected void btnClearInventoryData_Click(object sender, EventArgs e)
        {
            msgClearInventoryData.Text = _aDataManager.ClearInventoryData();
        }
    }
}