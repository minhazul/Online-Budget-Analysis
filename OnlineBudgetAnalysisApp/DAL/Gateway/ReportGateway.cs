using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.ViewModel;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class ReportGateway : Gateway
    {
        public List<Report> GetProjectWiseReport(int projectId)
        {
            Query =
                "SELECT CONVERT(CHAR(11), Date, 106) as Date, SKU, Category, Name, Sold, Prices, Total, PackagingCost, ActualShippingCost, UnitCost, MarketFee, VAT, TotalProductionCost, TotalCost, TotalEarning FROM Reports Where ProjectId=@ProjectId Order by Date";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("ProjectId", SqlDbType.Int);
            Command.Parameters["ProjectId"].Value = projectId;

            List<Report> reports = new List<Report>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Report aReport = new Report();

                aReport.Date = Convert.ToDateTime(Reader["Date"]);
                aReport.Sku = Reader["SKU"].ToString();
                aReport.Category = Reader["Category"].ToString();
                aReport.Name = Reader["Name"].ToString();
                aReport.Sold = Convert.ToInt32(Reader["Sold"]);
                aReport.Prices = Convert.ToDouble(Reader["Prices"]);
                aReport.Total = Convert.ToDouble(Reader["Total"]);
                aReport.PackagingCost = Convert.ToDouble(Reader["PackagingCost"]);
                aReport.ActualShippingCost = Convert.ToDouble(Reader["ActualShippingCost"]);
                aReport.UnitCost = Convert.ToDouble(Reader["UnitCost"]);
                aReport.MarketFee = Convert.ToDouble(Reader["MarketFee"]);
                aReport.Vat = Convert.ToDouble(Reader["VAT"]);
                aReport.TotalProdustionCost = Convert.ToDouble(Reader["TotalProductionCost"]);
                aReport.TotalCost = Convert.ToDouble(Reader["TotalCost"]);
                aReport.TotalEarning = Convert.ToDouble(Reader["TotalEarning"]);

                reports.Add(aReport);
            }

            Reader.Close();
            Connection.Close();

            return reports;
        }

        public List<Report> GetReportByDate(string startDate, string endDate)
        {
            Query =
                "SELECT CONVERT(CHAR(11), Date, 106) as Date, SKU, Category, Name, Sold, Prices, Total, PackagingCost, ActualShippingCost, UnitCost, MarketFee, VAT, TotalProductionCost, TotalCost, TotalEarning FROM Reports Where Date Between @StartDate AND @EndDate Order by Date";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("StartDate", SqlDbType.Date);
            Command.Parameters["StartDate"].Value = startDate;
            Command.Parameters.Add("EndDate", SqlDbType.Date);
            Command.Parameters["EndDate"].Value = endDate;

            List<Report> reports = new List<Report>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Report aReport = new Report();

                aReport.Date = Convert.ToDateTime(Reader["Date"]);
                aReport.Sku = Reader["SKU"].ToString();
                aReport.Category = Reader["Category"].ToString();
                aReport.Name = Reader["Name"].ToString();
                aReport.Sold = Convert.ToInt32(Reader["Sold"]);
                aReport.Prices = Convert.ToDouble(Reader["Prices"]);
                aReport.Total = Convert.ToDouble(Reader["Total"]);
                aReport.PackagingCost = Convert.ToDouble(Reader["PackagingCost"]);
                aReport.ActualShippingCost = Convert.ToDouble(Reader["ActualShippingCost"]);
                aReport.UnitCost = Convert.ToDouble(Reader["UnitCost"]);
                aReport.MarketFee = Convert.ToDouble(Reader["MarketFee"]);
                aReport.Vat = Convert.ToDouble(Reader["VAT"]);
                aReport.TotalProdustionCost = Convert.ToDouble(Reader["TotalProductionCost"]);
                aReport.TotalCost = Convert.ToDouble(Reader["TotalCost"]);
                aReport.TotalEarning = Convert.ToDouble(Reader["TotalEarning"]);

                reports.Add(aReport);
            }

            Reader.Close();
            Connection.Close();

            return reports;
        }

        public List<Report> GetreportByMonth(int month, int year)
        {
            Query =
                "SELECT CONVERT(CHAR(11), Date, 106) as Date, SKU, Category, Name, Sold, Prices, Total, PackagingCost, ActualShippingCost, UnitCost, MarketFee, VAT, TotalProductionCost, TotalCost, TotalEarning FROM Reports Where ( Year(Date)=@Year and Month(Date)=@Month) Order by Date";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Year", SqlDbType.VarChar);
            Command.Parameters["Year"].Value = year.ToString();
            Command.Parameters.Add("Month", SqlDbType.VarChar);
            Command.Parameters["Month"].Value = month.ToString();

            List<Report> reports = new List<Report>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Report aReport = new Report();

                aReport.Date = Convert.ToDateTime(Reader["Date"]);
                aReport.Sku = Reader["SKU"].ToString();
                aReport.Category = Reader["Category"].ToString();
                aReport.Name = Reader["Name"].ToString();
                aReport.Sold = Convert.ToInt32(Reader["Sold"]);
                aReport.Prices = Convert.ToDouble(Reader["Prices"]);
                aReport.Total = Convert.ToDouble(Reader["Total"]);
                aReport.PackagingCost = Convert.ToDouble(Reader["PackagingCost"]);
                aReport.ActualShippingCost = Convert.ToDouble(Reader["ActualShippingCost"]);
                aReport.UnitCost = Convert.ToDouble(Reader["UnitCost"]);
                aReport.MarketFee = Convert.ToDouble(Reader["MarketFee"]);
                aReport.Vat = Convert.ToDouble(Reader["VAT"]);
                aReport.TotalProdustionCost = Convert.ToDouble(Reader["TotalProductionCost"]);
                aReport.TotalCost = Convert.ToDouble(Reader["TotalCost"]);
                aReport.TotalEarning = Convert.ToDouble(Reader["TotalEarning"]);

                reports.Add(aReport);
            }

            Reader.Close();
            Connection.Close();

            return reports;
        }

        public List<Report> GetReportByYear(int year)
        {
            Query =
               "SELECT CONVERT(CHAR(11), Date, 106) as Date, SKU, Category, Name, Sold, Prices, Total, PackagingCost, ActualShippingCost, UnitCost, MarketFee, VAT, TotalProductionCost, TotalCost, TotalEarning FROM Reports Where (Year(Date)=@Year) Order by Date";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Year", SqlDbType.VarChar);
            Command.Parameters["Year"].Value = year.ToString();

            List<Report> reports = new List<Report>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Report aReport = new Report();

                aReport.Date = Convert.ToDateTime(Reader["Date"]);
                aReport.Sku = Reader["SKU"].ToString();
                aReport.Category = Reader["Category"].ToString();
                aReport.Name = Reader["Name"].ToString();
                aReport.Sold = Convert.ToInt32(Reader["Sold"]);
                aReport.Prices = Convert.ToDouble(Reader["Prices"]);
                aReport.Total = Convert.ToDouble(Reader["Total"]);
                aReport.PackagingCost = Convert.ToDouble(Reader["PackagingCost"]);
                aReport.ActualShippingCost = Convert.ToDouble(Reader["ActualShippingCost"]);
                aReport.UnitCost = Convert.ToDouble(Reader["UnitCost"]);
                aReport.MarketFee = Convert.ToDouble(Reader["MarketFee"]);
                aReport.Vat = Convert.ToDouble(Reader["VAT"]);
                aReport.TotalProdustionCost = Convert.ToDouble(Reader["TotalProductionCost"]);
                aReport.TotalCost = Convert.ToDouble(Reader["TotalCost"]);
                aReport.TotalEarning = Convert.ToDouble(Reader["TotalEarning"]);

                reports.Add(aReport);
            }

            Reader.Close();
            Connection.Close();

            return reports;
        }
    }

}