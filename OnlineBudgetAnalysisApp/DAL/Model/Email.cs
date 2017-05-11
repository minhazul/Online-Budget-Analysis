using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Model
{
    public class Email
    {
        public int Id { get; set; }
        public string EmailName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}