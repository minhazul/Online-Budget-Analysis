using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.ViewModel
{
    public class PendingUsers
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DesignationName { get; set; }
        public string Email { get; set; }
        public bool Is_Approved { get; set; }
        public string Registration_Date { get; set; }
        public bool IsAdmin_Approved { get; set; }
    }
}