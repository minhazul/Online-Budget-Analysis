using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Model
{
    public class UploadActivity
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string FullName { get; set; }
        public string Activity { get; set; }

    }
}