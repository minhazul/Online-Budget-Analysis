using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class EmailManager
    {
        EmailGateway _aEmailGateway=new EmailGateway();
        public Email GetCurrentEmailAndPassword()
        {
            return _aEmailGateway.GetCurrentEmailAndPassword();
        }

        public string ChangePassword(int id, string newPassword)
        {
            int rowAffected = _aEmailGateway.ChangePassword(id,newPassword);

            if (rowAffected>0)
            {
                return "Password Changed Successfully";
            }
            else
            {
                return "Password changed failed";
            }
        }

        public string ChangeEmailAndPassword(int currentEmailId, string newEmail, string newEmailPassword)
        {
            int firstRowAffected = _aEmailGateway.DeactivateCurrentEmail(currentEmailId);

            if (firstRowAffected > 0)
            {
                int secondRowAffected = _aEmailGateway.ActivateNewEmail(newEmail, newEmailPassword);

                if (secondRowAffected > 0)
                {
                    return "New Email has been activated";
                }
                else
                {
                    return
                        "New email activation failed. Please activate previous one first from email table and try again";
                }
            }
            else
            {
                return "Process failed. Please try again";
            }
        }

        public List<Email> GetAnotherEmails()
        {
            return _aEmailGateway.GetAnotherEmails();
        }

        public string ActivateAnotherEmail(int currentEmailId, int newEmailId)
        {
            int firstRowAffected = _aEmailGateway.DeactivateCurrentEmail(currentEmailId);

            if (firstRowAffected > 0)
            {
                int secondRowAffected = _aEmailGateway.ActivateAnotherEmailById(newEmailId);

                if (secondRowAffected > 0)
                {
                    return "activated successfully";
                }
                else
                {
                    return
                        "Previous email has been deactivated but somehow new email has not been activated. Please activate any email from the email table";
                }
            }
            else
            {
                return
                    "Process failed. Please try again";
            }
        }
    }
}