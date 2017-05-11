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
        public Email GetEmailAndPass()
        {
            return _aEmailGateway.GetEmailAndPass();
        }
    }
}