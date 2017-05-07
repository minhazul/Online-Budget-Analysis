using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class ReportManager
    {
        ReportGateway _aReportGateway=new ReportGateway();
        public List<Report> GetProjectWiseReport(int projectId)
        {
            return _aReportGateway.GetProjectWiseReport(projectId);
        }
    }
}