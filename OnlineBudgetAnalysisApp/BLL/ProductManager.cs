using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Gateway;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.BLL
{
    public class ProductManager
    {
        ProductGateway _aProductGateway=new ProductGateway();
        public string UpdateProductInfo(List<ProductInfo> productInfos)
        {
            int delRowAffected = _aProductGateway.DeleteProductinfoData();
            bool isProductInfoTableEmpty = _aProductGateway.IsProductInfoTableEmpty();
            if (delRowAffected > 0 || isProductInfoTableEmpty)
            {
                int updateRowAffected = _aProductGateway.UpdateProductInfo(productInfos);
                if (updateRowAffected > 0)
                {
                    return "Uploaded and updated data successfully";
                }
                else
                {
                    return "Data updating process failed";
                }
            }
            else
            {
                return "Upload successfull but failed to clear previous data. Please try to upload again";
            }
        }
    }
}