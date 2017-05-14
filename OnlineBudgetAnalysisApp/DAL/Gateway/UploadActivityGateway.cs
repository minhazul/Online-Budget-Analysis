using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class UploadActivityGateway:Gateway
    {
        public void UpdateActivityTable(int userId, string activity)
        {
            Query = "Insert Into tblUploadActivity(Date,UserId,Activity) Values(@Date,@UserId,@Activity)";

            Command=new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Date", SqlDbType.DateTime);
            Command.Parameters["Date"].Value = DateTime.Now;
            Command.Parameters.Add("UserId", SqlDbType.Int);
            Command.Parameters["UserId"].Value = userId;
            Command.Parameters.Add("Activity", SqlDbType.VarChar);
            Command.Parameters["Activity"].Value = activity;

            Connection.Open();

            Command.ExecuteNonQuery();

            Connection.Close();

        }

        public List<UploadActivity> GetUploadActivityInfo()
        {
            Query = "Select * From UploadActivityInfo Order by Date DESC";

            Command=new SqlCommand(Query,Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<UploadActivity> uploadActivities=new List<UploadActivity>();

            while (Reader.Read())
            {
                UploadActivity aUploadActivity=new UploadActivity();

                aUploadActivity.Date = Reader["Date"].ToString();
                aUploadActivity.FullName = Reader["FullName"].ToString();
                aUploadActivity.Activity = Reader["Activity"].ToString();

                uploadActivities.Add(aUploadActivity);
            }

            Reader.Close();
            Connection.Close();

            return uploadActivities;
        }
    }
}