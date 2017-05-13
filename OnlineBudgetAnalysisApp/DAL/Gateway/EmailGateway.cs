using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineBudgetAnalysisApp.DAL.Model;

namespace OnlineBudgetAnalysisApp.DAL.Gateway
{
    public class EmailGateway:Gateway
    {
        public Email GetCurrentEmailAndPassword()
        {
            Query = "Select * from ApplicationEmail Where Status=@Status";

            Command=new SqlCommand(Query,Connection);            

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.Bit);
            Command.Parameters["Status"].Value = true;

            Connection.Open();
            Reader = Command.ExecuteReader();

            Email aEmail=new Email();

            while (Reader.Read())
            {
                if (Reader.HasRows)
                {
                    aEmail.Id = Convert.ToInt32(Reader["Id"]);
                    aEmail.EmailName = Reader["Email"].ToString();
                    aEmail.Password = Reader["Password"].ToString();
                    aEmail.Status = Convert.ToBoolean(Reader["Status"]);
                }
            }

            Reader.Close();
            Connection.Close();

            return aEmail;
        }

        public int ChangePassword(int id, string newPassword)
        {
            Query = "Update ApplicationEmail Set Password=@Password Where Id=@Id";

            Command=new SqlCommand(Query,Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = newPassword;
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = id;

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public int DeactivateCurrentEmail(int currentEmailId)
        {
            Query = "Update ApplicationEmail Set Status=@Status Where Id=@Id";

            Command=new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.Bit);
            Command.Parameters["Status"].Value = false;
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = currentEmailId;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public int ActivateNewEmail(string newEmail, string newEmailPassword)
        {
            Query = "Insert Into ApplicationEmail(Email,Password) Values(@Email,@Password)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = newEmail;
            Command.Parameters.Add("Password", SqlDbType.VarChar);
            Command.Parameters["Password"].Value = newEmailPassword;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<Email> GetAnotherEmails()
        {
            Query = "Select * From ApplicationEmail Where Status=@Status";

            Command=new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.Bit);
            Command.Parameters["Status"].Value = false;

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Email> emails=new List<Email>();

            while (Reader.Read())
            {
                Email aEmail=new Email();

                aEmail.Id = Convert.ToInt32(Reader["Id"]);
                aEmail.EmailName = Reader["Email"].ToString();
                aEmail.Password = Reader["Password"].ToString();
                aEmail.Status = Convert.ToBoolean(Reader["Status"]);

                emails.Add(aEmail);
            }

            Reader.Close();
            Connection.Close();

            return emails;
        }

        public int ActivateAnotherEmailById(int newEmailId)
        {
            Query = "Update ApplicationEmail Set Status=@Status Where Id=@Id";

            Command=new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Status", SqlDbType.Bit);
            Command.Parameters["Status"].Value = true;
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = newEmailId;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
    }
}