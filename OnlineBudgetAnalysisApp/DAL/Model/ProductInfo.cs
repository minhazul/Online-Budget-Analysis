using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Model
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double UnitCost { get; set; }
        public double PackagingCost { get; set; }
        public double ActualShippingCost { get; set; }
        public double MarketFee { get; set; }
        public double Vat { get; set; }

    }
}