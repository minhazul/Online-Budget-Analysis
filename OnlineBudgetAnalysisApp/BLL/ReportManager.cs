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

        public List<Report> GetReportByDate(string startDate, string endDate)
        {
            return _aReportGateway.GetReportByDate(startDate, endDate);
        }

        public List<Report> GetReportByMonth(int month, int year)
        {
            return _aReportGateway.GetreportByMonth(month, year);
        }

        public List<Report> GetReportByYear(int year)
        {
            return _aReportGateway.GetReportByYear(year);
        }
    }
}