using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.ViewModel
{
    public class Report
    {
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public string Sku { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Sold { get; set; }
        public double Prices { get; set; }
        public double Total { get; set; }
        public double PackagingCost { get; set; }
        public double ActualShippingCost { get; set; }
        public double UnitCost { get; set; }
        public double MarketFee { get; set; }
        public double Vat { get; set; }
        public double TotalProdustionCost { get; set; }
        public double TotalCost { get; set; }
        public double TotalEarning { get; set; }
    }
}