using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class ProductGateway:Gateway
    {
        public int DeleteProductinfoData()
        {
            Query = "DELETE FROM ProductInfo";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();
            return rowAffected;
        }

        public bool IsProductInfoTableEmpty()
        {
            bool isEmpty = true;
            Query = "SELECT * FROM ProductInfo";
            Command = new SqlCommand(Query, Connection);           
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    isEmpty = false;
                }
            }
            
            Reader.Close();
            Connection.Close();
            return isEmpty;
        }

        public int UpdateProductInfo(List<ProductInfo> productInfos)
        {
            int rowAffected = 0;
            Query =
                "INSERT INTO ProductInfo(SKU,Category,Name,UnitCost,PackagingCost,ActualShippingCost,MarketFee,VAT) VALUES(@SKU,@Category,@Name,@UnitCost,@PackagingCost,@ActualShippingCost,@MarketFee,@VAT)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            foreach (var aproductinfo in productInfos)
            {
                Command.Parameters.Clear();
                Command.Parameters.Add("SKU", SqlDbType.VarChar);
                Command.Parameters["SKU"].Value = aproductinfo.Sku;
                Command.Parameters.Add("Category", SqlDbType.VarChar);
                Command.Parameters["Category"].Value = aproductinfo.Category;
                Command.Parameters.Add("Name", SqlDbType.VarChar);
                Command.Parameters["Name"].Value = aproductinfo.Name;
                Command.Parameters.Add("UnitCost", SqlDbType.Decimal);
                Command.Parameters["UnitCost"].Value = aproductinfo.UnitCost;
                Command.Parameters.Add("PackagingCost", SqlDbType.Decimal);
                Command.Parameters["PackagingCost"].Value = aproductinfo.PackagingCost;
                Command.Parameters.Add("ActualShippingCost", SqlDbType.Decimal);
                Command.Parameters["ActualShippingCost"].Value = aproductinfo.ActualShippingCost;
                Command.Parameters.Add("MarketFee", SqlDbType.Decimal);
                Command.Parameters["MarketFee"].Value = aproductinfo.MarketFee;
                Command.Parameters.Add("VAT", SqlDbType.Decimal);
                Command.Parameters["VAT"].Value = aproductinfo.Vat;

                rowAffected = Command.ExecuteNonQuery();

            }
            Connection.Close();

            return rowAffected;
        }
    }
}