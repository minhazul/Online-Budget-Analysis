using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int DesignationId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Is_Approved { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int RoleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsAdmin_Approved { get; set; }

    }
}