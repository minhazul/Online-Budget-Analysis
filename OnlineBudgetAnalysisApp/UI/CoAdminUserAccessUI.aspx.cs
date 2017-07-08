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
    public partial class CoAdminUserAccessUI : System.Web.UI.Page
    {
        UserAccessControlManager _accessControlManager=new UserAccessControlManager();
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            AccessControl();

            if (!IsPostBack)
            {
                PopulateCoAdminTableGridview();
            }
        }

        private void AccessControl()
        {
            string userName = Session["UserName"].ToString();

            int roleId = _aUsersManager.GetUserRoleId(userName);

            string roleName = _aUsersManager.GetRoleName(roleId);

            if (roleName == "CoAdmin" || roleName == "Normal")
            {
                Response.Redirect("ErrorUI.aspx");
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void PopulateCoAdminTableGridview()
        {
            List<AllUsersInfo> allUsersInfos=new List<AllUsersInfo>();
            allUsersInfos = _accessControlManager.GetAllCoAdminsInfo();

            if (allUsersInfos.Count==0)
            {
                msgLabel.Text = "Co-Admin list is empty";
            }

            CoAdminTableGridView.DataSource = allUsersInfos;
            CoAdminTableGridView.DataBind();
        }

        protected void CoAdminTableGridView_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control ctrl = e.Row.FindControl("CoAdminTableDropDownList");

                if(ctrl != null)
                {
                    DropDownList aDropDownList = ctrl as DropDownList;

                    List<ChangeAccess> changeAccesses=new List<ChangeAccess>();

                    for (int i = 0; i < 3; i++)
                    {
                        ChangeAccess aChangeAccess=new ChangeAccess();

                        if (i == 1)
                        {
                            aChangeAccess.Id = i;
                            aChangeAccess.Action = "Normal";
                            changeAccesses.Add(aChangeAccess);
                        }
                        else if (i == 2)
                        {
                            aChangeAccess.Id = i;
                            aChangeAccess.Action = "Block";
                            changeAccesses.Add(aChangeAccess);
                        }
                        else
                        {
                            aChangeAccess.Id = i;
                            aChangeAccess.Action = "--Select one--";
                            changeAccesses.Add(aChangeAccess);
                        }
                    }

                    if (aDropDownList != null)
                    {
                        aDropDownList.DataSource = changeAccesses;
                        aDropDownList.DataTextField = "Action";
                        aDropDownList.DataValueField = "Id";
                        aDropDownList.DataBind();
                    }
                }
            }
        }

        protected void CoAdminTableDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList aDropDownList = sender as DropDownList;

            foreach (GridViewRow row in CoAdminTableGridView.Rows)
            {
                Control ctrl = row.FindControl("CoAdminTableDropDownList") as DropDownList;

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
                            string changedRole = "Normal";
                            string message = _accessControlManager.ChangeRole(userId,changedRole);
                            msgLabel.Text = message;

                            PopulateCoAdminTableGridview();
                        }
                        else if (selectId == 2)
                        {
                            string message = _accessControlManager.BlockUserById(userId);
                            msgLabel.Text = message;

                            PopulateCoAdminTableGridview();
                        }
                        else
                        {
                            msgLabel.Text = "Please select a valid action from CoAdmin Table";
                        }
                    }
                }
            }
        }

    }
}