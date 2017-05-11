using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp
{
    public partial class RecoverPasswordUI : System.Web.UI.Page
    {
        UsersManager _aUsersManager=new UsersManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecoverPass_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Value;
            string emailid = txtEmail.Value;
            bool isUserNameExists = _aUsersManager.IsUserNameExists(userName);
            bool isEmailExists = _aUsersManager.IsEmailExists(emailid);


            if (isUserNameExists == true && isEmailExists == true)
            {
                string activationUrl;
                try
                {
                        Email aEmail = new Email();
                        EmailManager aEmailManager = new EmailManager();
                        aEmail = aEmailManager.GetEmailAndPass();
                  
                        var msg = new MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        emailid = txtEmail.Value.Trim();

                        msg.From = new MailAddress("minhazcste14@gmail.com");
                        msg.To.Add(emailid);
                        msg.Subject = "Password recovery";

                        activationUrl = Server.HtmlEncode("http://localhost:9429/UI/ResetPasswordUi.aspx?UserID=" + userName + "&EmailId=" + emailid);

                        msg.Body = "Hi " + userName + "!\n" +
                          "Please go to this link  " +
                          "<a href='" + activationUrl + "'>click here to reset password</a>. \nThanks!";
                        msg.IsBodyHtml = true;

                        smtp.Credentials = new NetworkCredential(aEmail.EmailName, aEmail.Password);
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.Send(msg);
                        clear_controls();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('a password reset link is sent to you email');", true);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                    return;
                }
                finally
                {
                    activationUrl = string.Empty;
                    emailid = string.Empty;                   
                }
            }
            else
            {
                msgLabel.Text = "UserName or email doesn't match";
            }
        }

        private void clear_controls()
        {
            txtUserName.Value=String.Empty;
            txtEmail.Value=String.Empty;
        }
    }
}