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
    public partial class PendingApprovalUI : System.Web.UI.Page
    {
        PendingUserManager aPendingUserManager = new PendingUserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PopulatePendingUsersGridView();
            }


        }

        private void PopulatePendingUsersGridView()
        {
            List<PendingUsers> pendingUsers = new List<PendingUsers>();
            pendingUsers = aPendingUserManager.GetPendingUsersList();

            if (pendingUsers.Count == 0)
            {
                msgLabel.Text = "The list is empty";
            }

            pendingApprovalGridView.DataSource = pendingUsers;
            pendingApprovalGridView.DataBind();
        }

        protected void pendingApprovalGridView_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control ctrl = e.Row.FindControl("approveOrDeleteDropDownList");

                if (ctrl != null)
                {
                    DropDownList aDropDownList = ctrl as DropDownList;

                    List<ApproveDelete> approveDeletes = new List<ApproveDelete>();

                    for (int i = 0; i < 3; i++)
                    {
                        ApproveDelete approveDelete = new ApproveDelete();

                        if (i == 1)
                        {
                            approveDelete.Id = i;
                            approveDelete.Action = "Approve";
                            approveDeletes.Add(approveDelete);
                        }
                        else if (i == 2)
                        {
                            approveDelete.Id = i;
                            approveDelete.Action = "Delete";
                            approveDeletes.Add(approveDelete);
                        }
                        else
                        {
                            approveDelete.Id = i;
                            approveDelete.Action = "--Select One--";
                            approveDeletes.Add(approveDelete);
                        }
                    }

                    if (aDropDownList != null)
                    {
                        aDropDownList.DataSource = approveDeletes;
                        aDropDownList.DataTextField = "Action";
                        aDropDownList.DataValueField = "Id";
                        aDropDownList.DataBind();
                    }
                }
            }
        }

        protected void approveOrDeleteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList aDropDownList = sender as DropDownList;

            foreach (GridViewRow row in pendingApprovalGridView.Rows)
            {
                Control ctrl = row.FindControl("approveOrDeleteDropDownList") as DropDownList;



                if (ctrl != null)
                {
                    DropDownList abDropDownList = (DropDownList)ctrl;

                    DataControlFieldCell cell = abDropDownList.Parent as DataControlFieldCell;
                    GridViewRow selectedRow = cell.Parent as GridViewRow;
                    HiddenField selectedHiddenField = selectedRow.FindControl("idHiddenField") as HiddenField;
                    int userId = Convert.ToInt32(selectedHiddenField.Value);

                    if (aDropDownList.ClientID == abDropDownList.ClientID)
                    {
                        int selectId = Convert.ToInt32(abDropDownList.SelectedValue);

                        if (selectId == 1)
                        {
                            aPendingUserManager.ApproveUserById(userId);
                            PopulatePendingUsersGridView();
                        }
                        else if (selectId == 2)
                        {
                            aPendingUserManager.DeleteUserById(userId);
                            PopulatePendingUsersGridView();
                        }
                        else
                        {
                            msgLabel.Text = "Please select an action from dropdownlist";
                        }
                    }

                }
            }
        }
    }
}