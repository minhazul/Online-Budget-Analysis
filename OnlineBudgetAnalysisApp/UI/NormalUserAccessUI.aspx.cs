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
    public partial class NormalUserAccessUI : System.Web.UI.Page
    {
        UserAccessControlManager _accessControlManager = new UserAccessControlManager();
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            AccessControl();

            if (!IsPostBack)
            {
                PopulateNormalUsersGridView();
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

        private void PopulateNormalUsersGridView()
        {
            List<AllUsersInfo> allUsersInfos = new List<AllUsersInfo>();
            allUsersInfos = _accessControlManager.GetAllNormalUsersInfo();

            if (allUsersInfos.Count == 0)
            {
                
                msgNormalLabel.Text = "Normal User List is empty";
                paddingControl1.Style.Add("padding-bottom", "400px");
            }

            else if (allUsersInfos.Count == 1)
            {
                
                paddingControl.Style.Add("padding-bottom", "360px");
            }
            else if (allUsersInfos.Count == 2)
            {
                
                paddingControl.Style.Add("padding-bottom", "320px");
            }
            else if (allUsersInfos.Count == 3)
            {
                
                paddingControl.Style.Add("padding-bottom", "280px");
            }
            else if (allUsersInfos.Count == 4)
            {
                
                paddingControl.Style.Add("padding-bottom", "240px");
            }
            else if (allUsersInfos.Count == 5)
            {
                
                paddingControl.Style.Add("padding-bottom", "200px");
            }
            else if (allUsersInfos.Count == 6)
            {
                
                paddingControl.Style.Add("padding-bottom", "160px");
            }
            else if (allUsersInfos.Count == 7)
            {
                
                paddingControl.Style.Add("padding-bottom", "120px");
            }
            else if (allUsersInfos.Count == 8)
            {
                
                paddingControl.Style.Add("padding-bottom", "80px");
            }
            else if (allUsersInfos.Count == 9)
            {
                
                paddingControl.Style.Add("padding-bottom", "40px");
            }
            else if (allUsersInfos.Count > 9)
            {
                
                paddingControl.Style.Add("padding-bottom", "20px");
            }

            normalUserGridView.DataSource = allUsersInfos;
            normalUserGridView.DataBind();
        }

        protected void normalUserGridView_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control ctrl = e.Row.FindControl("normalUserDropDownList");

                if (ctrl != null)
                {
                    DropDownList aDropDownList = ctrl as DropDownList;

                    List<ChangeAccess> changeAccesses = new List<ChangeAccess>();

                    for (int i = 0; i < 3; i++)
                    {
                        ChangeAccess aChangeAccess = new ChangeAccess();

                        if (i == 1)
                        {
                            aChangeAccess.Id = i;
                            aChangeAccess.Action = "CoAdmin";
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

        protected void normalUserDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList aDropDownList = sender as DropDownList;

            foreach (GridViewRow row in normalUserGridView.Rows)
            {
                Control ctrl = row.FindControl("normalUserDropDownList") as DropDownList;

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
                            string changedRole = "CoAdmin";
                            string message = _accessControlManager.ChangeRole(userId, changedRole);
                            msgNormalLabel.Text = message;

                            PopulateNormalUsersGridView();
                        }
                        else if (selectId == 2)
                        {
                            string message = _accessControlManager.BlockUserById(userId);
                            msgNormalLabel.Text = message;

                            PopulateNormalUsersGridView();
                        }
                        else
                        {
                            msgNormalLabel.Text = "Please select a valid action from CoAdmin Table";
                        }
                    }
                }
            }
        }
    }
}