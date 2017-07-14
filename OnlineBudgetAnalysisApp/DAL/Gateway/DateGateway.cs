using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class DateGateway:Gateway
    {
        public List<Year> GetYears()
        {
            Query = "Select * from tblYear";
            Command=new SqlCommand(Query,Connection);

            List<Year> years=new List<Year>();

            //Year bYear = new Year();
            //bYear.Id = -1;
            //bYear.YearNo = 0;
            //years.Add(bYear);

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Year aYear=new Year();

                if (Reader.HasRows)
                {
                    aYear.Id = Convert.ToInt32(Reader["Id"]);
                    aYear.YearNo = Convert.ToInt32(Reader["Year"]);
                }

                years.Add(aYear);
            }

            Reader.Close();
            Connection.Close();

            return years;
        }

        public List<Month> GetMonths()
        {
            Query = "Select * from tblMonth";
            Command=new SqlCommand(Query,Connection);

            List<Month> months=new List<Month>();

            Month bMonth = new Month();
            bMonth.Id = -1;
            bMonth.MonthName = "--Select One--";
            months.Add(bMonth);

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Month aMonth=new Month();

                if (Reader.HasRows)
                {
                    aMonth.Id = Convert.ToInt32(Reader["Id"]);
                    aMonth.MonthName = Reader["Month"].ToString();
                }

                months.Add(aMonth);
            }

            Reader.Close();
            Connection.Close();

            return months;
        }
    }
}