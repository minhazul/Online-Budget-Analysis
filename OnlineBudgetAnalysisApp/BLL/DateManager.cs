using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class DateManager
    {
        DateGateway _aDateGateway=new DateGateway();
        public List<Year> GetYears()
        {
            return _aDateGateway.GetYears();
        }

        public List<Month> GetMonths()
        {
            return _aDateGateway.GetMonths();
        }
    }
}