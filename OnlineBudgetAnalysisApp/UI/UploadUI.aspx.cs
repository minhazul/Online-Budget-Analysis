using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineBudgetAnalysisApp.BLL;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class UploadUI : System.Web.UI.Page
    {
        ProductManager _aProductManager=new ProductManager();
        ProjectManager _aProjectManager=new ProjectManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectDropdownList();
            }
        }

        private void PopulateProjectDropdownList()
        {
            List<Projects> projects=new List<Projects>();
            projects = _aProjectManager.GetAllProjects();

            ddlpjcts.DataSource = projects;
            ddlpjcts.DataTextField = "ProjectName";
            ddlpjcts.DataValueField = "Id";
            ddlpjcts.DataBind();

            if (ddlpjcts.Items.Count > 1)
            {
                ddlpjcts.Enabled = true;
            }
            else
            {
                ddlpjcts.Enabled = false;
            }
        }

        protected void btnPrdctInfoUpload_Click(object sender, EventArgs e)
        {
            
            List<ProductInfo> productInfos=new List<ProductInfo>();
            
            try
            {
                var filename = prdctInfoUpload.PostedFile.FileName;
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                prdctInfoUpload.PostedFile.SaveAs(Server.MapPath(".") + "/uploads/" + filename);

                DataSet dsRecords = new DataSet();

                string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(".") + "/uploads/" +
                                 filename + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                OleDbDataAdapter daGetExcel = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
                daGetExcel.Fill(dsRecords, "Sheet1");

                foreach (DataRow myDataRow in dsRecords.Tables["Sheet1"].Rows)
                {
                    ProductInfo aProductInfo = new ProductInfo();

                    if (myDataRow[0].ToString() != "")
                    {
                        aProductInfo.Sku = myDataRow[0].ToString();
                        aProductInfo.Category = myDataRow[1].ToString();
                        aProductInfo.Name = myDataRow[2].ToString();
                        String uc = myDataRow[3].ToString();
                        String pc = myDataRow[4].ToString();
                        String sc = myDataRow[5].ToString();
                        String mf = myDataRow[6].ToString();
                        String invat = myDataRow[5].ToString();
                        aProductInfo.UnitCost = Double.Parse(uc);
                        aProductInfo.PackagingCost = Double.Parse(pc);
                        aProductInfo.ActualShippingCost = Double.Parse(sc);
                        aProductInfo.MarketFee = Double.Parse(mf);
                        aProductInfo.Vat = Double.Parse(invat);

                        productInfos.Add(aProductInfo);

                    }
                }

                if (productInfos.Count == 0)
                {
                    msgPrdctInfoLabel.Text = "File reading process failed. Please try to upload again";
                }
                else
                {
                    string message = _aProductManager.UpdateProductInfo(productInfos);
                    msgPrdctInfoLabel.Text = message;
                }

                
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Process failed due to exception error. Please test your connection speed and try again. Otherwise contact with admin');", true);
            }
        }

        protected void btnDailyInventoryUpload_Click(object sender, EventArgs e)
        {
            List<Inventory> inventories=new List<Inventory>();

            try
            {
                var filename = dailyInventoryUpload.PostedFile.FileName;
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                dailyInventoryUpload.PostedFile.SaveAs(Server.MapPath(".") + "/uploads/" + filename);

                DataSet dsRecords = new DataSet();

                string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(".") + "/uploads/" +
                                 filename + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                OleDbDataAdapter daGetExcel = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
                daGetExcel.Fill(dsRecords, "Sheet1");

                foreach (DataRow myDataRow in dsRecords.Tables["Sheet1"].Rows)
                {
                    Inventory aInventory=new Inventory();

                    if (myDataRow[0].ToString() != "")
                    {
                        aInventory.Sku = myDataRow[0].ToString();
                        String sd = myDataRow[1].ToString();
                        String pr = myDataRow[2].ToString();
                        aInventory.Sold= Double.Parse(sd);
                        aInventory.Prices = Double.Parse(pr);
                        aInventory.ProjectId = Convert.ToInt32(ddlpjcts.SelectedValue);

                        inventories.Add(aInventory);
                    }
                }

                if (inventories.Count == 0)
                {
                    msgDailyInventoryUpload.Text = "File reading process failed. Please try to upload again";
                }
                else
                {
                    string message = _aProductManager.DailyInventoryEntries(inventories);
                    msgDailyInventoryUpload.Text = message;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}