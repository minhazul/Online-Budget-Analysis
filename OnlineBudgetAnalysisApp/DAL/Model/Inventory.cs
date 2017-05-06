using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public double Sold { get; set; }
        public double Prices { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }

    }
}