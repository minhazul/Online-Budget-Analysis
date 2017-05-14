using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class DataManager
    {
        DataGateway _aDataGateway=new DataGateway();
        public string ClearProductInfoData()
        {
            int rowAffected = _aDataGateway.ClearProductInfoData();

            if (rowAffected>0)
            {
                return "Data Cleared successfully";
            }
            else
            {
                return "Data couldn't be cleared. Please try again";
            }
        }
    }
}