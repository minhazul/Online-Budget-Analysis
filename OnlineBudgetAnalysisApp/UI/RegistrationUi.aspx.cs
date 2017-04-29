using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp
{
    public partial class RegistrationUi : System.Web.UI.Page
    {
        Users _aUsers=new Users();
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            MailMessage msg;
            string activationUrl = string.Empty;
            string emailId = string.Empty;

            try
            {
                _aUsers.FullName = txtFullName.Text;
                _aUsers.UserName = userNameTextBox.Text;
                _aUsers.Email = txtEmail.Text;
                _aUsers.Password = passTextBox.Text;
                string RoleName = "Normal";
                _aUsers.RoleId = _aUsersManager.GetRoleId(RoleName);
                
                string registerUser = _aUsersManager.RegisterUser(_aUsers);
                if (registerUser == "success")
                {
                    
                    msgLabel.Text = "Registerd successfully";

                    //Sending activation link in the email
                    msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    emailId = txtEmail.Text.Trim();

                    //sender email address
                    msg.From = new MailAddress("minhazcste14@gmail.com");

                    //Receiver email address
                    msg.To.Add(emailId);

                    msg.Subject = "Confirmation email for account activation";
                    
                    string userId = FetchUserId(emailId);
                 
                    activationUrl = Server.HtmlEncode("http://localhost:9429/UI/ActivateAccount.aspx?EmailId=" + emailId + "&UserId=" + userId);

                    msg.Body = "Hi " + txtFullName.Text.Trim() + "!\n" +
                          "Thanks for registring in Online Budget Analysis System " +
                          " Please <a href='" + activationUrl + "'>click here to activate</a>  your account. \nThanks!";
                    msg.IsBodyHtml = true;

                    smtp.Credentials = new NetworkCredential("minhazcste14@gmail.com", "14tintumun44");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    smtp.Send(msg);
                    clear_controls();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Confirmation Link to activate your account has been sent to your email address');", true);
                }
                
            }
            catch (Exception ex)
            {
                string message = _aUsersManager.DropData(_aUsers.UserName, _aUsers.Email);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + message + "');", true);
                return;
            }
            finally
            {
                activationUrl = string.Empty;
                emailId = string.Empty;
            }
        }

        private string FetchUserId(string emailId)
        {
            string email = _aUsersManager.FetchUserId(emailId);
            return email;
        }


        private void clear_controls()
        {
            userNameTextBox.Text=String.Empty;
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            passTextBox.Text = string.Empty;
            //fullNameTextBox.Focus();
        }
    }
}