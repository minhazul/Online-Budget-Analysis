using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.ViewModel
{
    public class ProjectListShow
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectHeadName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}