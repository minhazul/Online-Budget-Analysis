using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class gui : System.Web.UI.Page
    {
        ProductManager _aProductManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateProductListGridView();
        }

        private void PopulateProductListGridView()
        {
            List<ProductInfo> prdctLists = _aProductManager.GetAllProducts();

            GridView1.DataSource = prdctLists;

            GridView1.DataBind();
        }
    }
}