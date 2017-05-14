using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class UploadActivityManager
    {
        UploadActivityGateway _activityGateway=new UploadActivityGateway();
        public void UpdateActivityTable(int userId, string activity)
        {
            _activityGateway.UpdateActivityTable(userId,activity);
        }

        public List<UploadActivity> GetUploadActivityInfo()
        {
            return _activityGateway.GetUploadActivityInfo();
        }
    }
}