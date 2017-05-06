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
        public int ProjectHeadId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        
    }
}