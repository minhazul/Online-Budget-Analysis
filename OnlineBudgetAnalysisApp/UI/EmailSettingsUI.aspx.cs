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
    public partial class EmailSettingsUI : System.Web.UI.Page
    {
        EmailManager _aEmailManager=new EmailManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            if (!IsPostBack)
            {
                GenerateCurrentEmailAndPassword();
                PopulateAnotherEmailLists();
            }
        }

        private void SessionControl()
        {
            if(Session["UserName"]==null)
                Response.Redirect("HomeUI.aspx");
        }


        private void PopulateAnotherEmailLists()
        {
            List<Email> emails = new List<Email>();
            emails = _aEmailManager.GetAnotherEmails();

            if (emails.Count!=0)
            {
                ApplicationEmailListsGridView.DataSource = emails;
                ApplicationEmailListsGridView.DataBind();
            }
            else
            {
                msgGridEmailListsLabel.Text = "Another email list is empty";
            }
        }

        private void GenerateCurrentEmailAndPassword()
        {
            Email aEmail=new Email();
            aEmail = _aEmailManager.GetCurrentEmailAndPassword();

            msgCurrentEmail.Text = aEmail.EmailName;
            msgCurrentPassword.Text = aEmail.Password;
        }

        protected void btnCHangedPasswordSubmit_Click(object sender, EventArgs e)
        {
            Email aEmail=new Email();
            aEmail = _aEmailManager.GetCurrentEmailAndPassword();

            string newPassword = txtChangeApplicationEmailPassword.Text;
            string confirmNewPassword = txtConfirmChangeApplicationEmailPassword.Text;

            if (newPassword == confirmNewPassword)
            {
                string message = _aEmailManager.ChangePassword(aEmail.Id, newPassword);
                chngPasswordLabel.Text = message;
            }
            else
            {
                chngPasswordLabel.Text = "Paaword doesn't match";
            }
            
        }

        protected void btnNewEmailAndPassword_Click(object sender, EventArgs e)
        {
            Email aEmail=new Email();
            aEmail = _aEmailManager.GetCurrentEmailAndPassword();
            int currentEmailId = aEmail.Id;

            string newEmail = txtNewEmail.Text;
            string newEmailPassword = txtNewEmailPassword.Text;
            string confirmNewEmailPassword = txtConfirmNewEmailPassword.Text;

            if (newEmailPassword == confirmNewEmailPassword)
            {
                string message = _aEmailManager.ChangeEmailAndPassword(currentEmailId,newEmail,newEmailPassword);
                msgchngEmailLabel.Text = message;
            }
            else
            {
                msgchngEmailLabel.Text = "Password doesn't match";
            }
        }

        protected void activateLinkButton_OnClick(object sender, EventArgs e)
        {
            Email aEmail = _aEmailManager.GetCurrentEmailAndPassword();
            int currentEmailId = aEmail.Id;

            LinkButton activateButton = sender as LinkButton;
            DataControlFieldCell cell = activateButton.Parent as DataControlFieldCell;
            GridViewRow selectedRow = cell.Parent as GridViewRow;
            HiddenField selectedHiddenField = selectedRow.FindControl("idHiddenField") as HiddenField;
            int newEmailId = Convert.ToInt32(selectedHiddenField.Value);

            string message = _aEmailManager.ActivateAnotherEmail(currentEmailId, newEmailId);
            msgGridEmailListsLabel.Text = message;

            GenerateCurrentEmailAndPassword();
            PopulateAnotherEmailLists();
        }
    }
}