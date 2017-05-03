using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Model
{
    public class Projects
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectHead { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        
    }
}