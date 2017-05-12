﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBudgetAnalysisApp.DAL.ViewModel
{
    public class BlockedUserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string RegistrationDate { get; set; }
        public string LastLoginDate { get; set; }
    }
}