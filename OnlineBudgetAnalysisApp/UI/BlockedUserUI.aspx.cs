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
    public partial class BlockedUserUI : System.Web.UI.Page
    {
        BlockedUserManager _aBlockedUserManager=new BlockedUserManager();
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            AccessControl();

            if (!IsPostBack)
            {
                PopulateBlockedUserGridView();
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

        private void PopulateBlockedUserGridView()
        {
            List<BlockedUserInfo> blockedUserInfos=new List<BlockedUserInfo>();
            blockedUserInfos = _aBlockedUserManager.GetAllBlockedUsers();

            if (blockedUserInfos.Count == 0)
            {
                msgLabel.Text = "The list is empty";
                paddingControl1.Style.Add("padding-bottom", "400px");
            }

            else if (blockedUserInfos.Count == 1)
            {

                paddingControl.Style.Add("padding-bottom", "360px");
            }
            else if (blockedUserInfos.Count == 2)
            {

                paddingControl.Style.Add("padding-bottom", "320px");
            }
            else if (blockedUserInfos.Count == 3)
            {

                paddingControl.Style.Add("padding-bottom", "280px");
            }
            else if (blockedUserInfos.Count == 4)
            {

                paddingControl.Style.Add("padding-bottom", "240px");
            }
            else if (blockedUserInfos.Count == 5)
            {

                paddingControl.Style.Add("padding-bottom", "200px");
            }
            else if (blockedUserInfos.Count == 6)
            {

                paddingControl.Style.Add("padding-bottom", "160px");
            }
            else if (blockedUserInfos.Count == 7)
            {

                paddingControl.Style.Add("padding-bottom", "120px");
            }
            else if (blockedUserInfos.Count == 8)
            {

                paddingControl.Style.Add("padding-bottom", "80px");
            }
            else if (blockedUserInfos.Count == 9)
            {

                paddingControl.Style.Add("padding-bottom", "40px");
            }
            else if (blockedUserInfos.Count > 9)
            {

                paddingControl.Style.Add("padding-bottom", "20px");
            }

            blockedUserGridView.DataSource = blockedUserInfos;
            blockedUserGridView.DataBind();
        }

        protected void blockedUserGridView_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control ctrl = e.Row.FindControl("allowOrDeleteDropDownList");

                if (ctrl != null)
                {
                    DropDownList aDropDownList = ctrl as DropDownList;

                    List<AllowOrDelete> allowOrDeletes=new List<AllowOrDelete>();

                    for (int i = 0; i < 3; i++)
                    {
                        AllowOrDelete allowOrDelete=new AllowOrDelete();

                        if (i == 1)
                        {
                            allowOrDelete.Id = i;
                            allowOrDelete.Action = "Allow";
                            allowOrDeletes.Add(allowOrDelete);
                        }
                        else if (i==2)
                        {
                            allowOrDelete.Id = i;
                            allowOrDelete.Action = "Delete";
                            allowOrDeletes.Add(allowOrDelete);
                        }
                        else
                        {
                            allowOrDelete.Id = i;
                            allowOrDelete.Action = "--Select one--";
                            allowOrDeletes.Add(allowOrDelete);
                        }
                    }

                    if (aDropDownList != null)
                    {
                        aDropDownList.DataSource = allowOrDeletes;
                        aDropDownList.DataTextField = "Action";
                        aDropDownList.DataValueField = "Id";
                        aDropDownList.DataBind();
                    }
                }
            }
        }

        protected void allowOrDeleteDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList aDropDownList = sender as DropDownList;

            foreach (GridViewRow row in blockedUserGridView.Rows)
            {
                Control ctrl = row.FindControl("allowOrDeleteDropDownList") as DropDownList;

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

                        if (selectId==1)
                        {
                            _aBlockedUserManager.AllowBlockedUserById(userId);
                            PopulateBlockedUserGridView();
                        }
                        else if (selectId==2)
                        {
                            _aBlockedUserManager.DeleteUserById(userId);
                            PopulateBlockedUserGridView();
                        }
                        else
                        {
                            msgLabel.Text = "Please select a valid action from dropdownlist";
                        }
                    }
                }
            }
        }
    }
}