using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class DesignationManager
    {
        DesignationGateway _aDesignationGateway=new DesignationGateway();
        public List<Designation> GetAllDesignation()
        {
            return _aDesignationGateway.GetAllDesignatios();
        }
    }
}