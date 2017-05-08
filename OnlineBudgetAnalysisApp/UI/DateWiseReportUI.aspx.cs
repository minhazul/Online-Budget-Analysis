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
    public partial class DateWiseReportUI : System.Web.UI.Page
    {
        string userName;
        UsersManager _aUsersManager = new UsersManager();
        ReportManager _aReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userName = Session["UserName"].ToString();
                string fullName = _aUsersManager.GetFullName(userName);
                msgFullName.Text = fullName;
                
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string startDate = StartTextBox.Text;
            string endDate = EndTextBox.Text;

            if (startDate != null && endDate != null)
            {
                PopulateDateWiseDridView(startDate, endDate);
            }
            else
            {
                msgError.Text = "Please select start date and end date";
            }            
        }

        private void PopulateDateWiseDridView(string startDate, string endDate)
        {
            List<Report> reports=new List<Report>();
            reports = _aReportManager.GetReportByDate(startDate, endDate);

            DateWiseReportGridView.DataSource = reports;
            DateWiseReportGridView.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeUI.aspx");
        }
    }
}