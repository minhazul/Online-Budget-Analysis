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
    public partial class MonthWiseReportUI : System.Web.UI.Page
    {
        string userName;
        UsersManager _aUsersManager = new UsersManager();
        DateManager _aDateManager = new DateManager();
        ReportManager _aReportManager = new ReportManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            if (!IsPostBack)
            {
                userName = Session["UserName"].ToString();
                string fullName = _aUsersManager.GetFullName(userName);
                msgFullName.Text = fullName;

                PopulateMonthDropDown();
                PopulateYearDropDown();
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"]==null)
            {
                Response.Redirect("HomeUI.aspx");
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
        }

        private void PopulateMonthDropDown()
        {
            List<Month> months = new List<Month>();
            months = _aDateManager.GetMonths();

            monthDropDownList.DataSource = months;
            monthDropDownList.DataTextField = "MonthName";
            monthDropDownList.DataValueField = "Id";
            monthDropDownList.DataBind();
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(monthDropDownList.SelectedValue);
            int year = Convert.ToInt32(yearDropDownList.SelectedValue);

            List<Report> reports = new List<Report>();
            reports = _aReportManager.GetReportByMonth(month, year);

            if (reports.Count == 0)
            {
                MonthWiseReportGridView.DataSource = null;
                MonthWiseReportGridView.DataBind();

                msgLists.Text = "The list is empty";
            }
            else
            {
                msgLists.Text=String.Empty;

                paddingControl.Style.Add("padding-top", "15px");
                paddingControl.Style.Add("padding-bottom", "15px");
                

                //msgFullName.Text = fullName;
                MonthWiseReportGridView.DataSource = reports;
                MonthWiseReportGridView.DataBind();
            }

        }
    }
}