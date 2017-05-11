using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class YearWiseReportUI : System.Web.UI.Page
    {
        string userName;
        UsersManager _aUsersManager = new UsersManager();
        DateManager _aDateManager = new DateManager();
        ReportManager _aReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userName = Session["UserName"].ToString();
                string fullName = _aUsersManager.GetFullName(userName);
                msgFullName.Text = fullName;
                PopulateYearDropDown();
            }
        }

        private void PopulateYearDropDown()
        {
            List<Year> years = new List<Year>();
            years = _aDateManager.GetYears();

            yearDropDownList.DataSource = years;
            yearDropDownList.DataTextField = "YearNo";
            yearDropDownList.DataValueField = "YearNo";
            yearDropDownList.DataBind();

            if (yearDropDownList.Items.Count > 1)
            {
                yearDropDownList.Enabled = true;
            }
            else
            {
                yearDropDownList.Enabled = false;
            }
        }

        protected void dropDownYearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(yearDropDownList.SelectedValue);
            PopulateYearWiseReportGridView(year);
        }

        private void PopulateYearWiseReportGridView(int year)
        {
            List<Report> reports = new List<Report>();
            reports = _aReportManager.GetReportByYear(year);

            YearWiseGridView.DataSource = reports;
            YearWiseGridView.DataBind();
        }
    }
}