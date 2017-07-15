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
    public partial class ProductListUI : System.Web.UI.Page
    {
        private string userName = null;
        UsersManager _aUsersManager = new UsersManager();
        ProductManager _aProductManager = new ProductManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();

            userName = Session["UserName"].ToString();
            PopulatePrdctListGridView();
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("HomeUI.aspx");
            }
        }

        private void PopulatePrdctListGridView()
        {
            List<ProductInfo> prdctLists = _aProductManager.GetAllProducts();

            if (prdctLists.Count == 0)
            {
                msgLists.Text = "Product list is empty";
            }

            else
            {
                //string fullName = _aUsersManager.GetFullName(userName);
                //msgFullName.Text = fullName;

                prdctListGridview.DataSource = prdctLists;
                prdctListGridview.DataBind();
            }
        }
    }
}