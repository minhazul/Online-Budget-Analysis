using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineBudgetAnalysisApp.UI
{
    public partial class ActivateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActivateMyAccount();
        }

        private void ActivateMyAccount()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBudgetAnalysisDB"].ConnectionString);

                if ((!string.IsNullOrEmpty(Request.QueryString["UserID"])) & (!string.IsNullOrEmpty(Request.QueryString["EmailId"])))
                {   //approve account by setting Is_Approved to 1 i.e. True in the sql server table                   
                    cmd = new SqlCommand("UPDATE Users SET Is_Approved=1 WHERE UserName=@UserID AND Email=@EmailId", con);
                    cmd.Parameters.AddWithValue("@UserID", Request.QueryString["UserID"]);
                    cmd.Parameters.AddWithValue("@EmailId", Request.QueryString["EmailId"]);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();

                    Response.Write("You account has been activated. You can <a href='http://localhost:9429/UI/LoginUI.aspx'>Login</a> now! ");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                return;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }
    }
}