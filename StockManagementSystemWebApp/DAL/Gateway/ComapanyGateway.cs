using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ComapanyGateway:Gateway
    {

        public int Save(Company aCompany)
        {
            Query = "INSERT INTO CompanyTable(Company) VALUES(@company)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@company", SqlDbType.VarChar);
            Command.Parameters["@company"].Value = aCompany.CompanyName;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Company> GetAllCompanies()
        {
            Query = "SELECT * FROM CompanyTable";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            List<Company> companies = new List<Company>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Company aCompany = new Company();
                aCompany.CompanyName = Reader["Company"].ToString();
                aCompany.CompanyId = Convert.ToInt32(Reader["Id"].ToString());
                companies.Add(aCompany);
            }
            Connection.Close();
            Reader.Close();
            return companies;
        }



        public bool IsCompanyExist(string companyName)
        {
            Query = "SELECT * FROM CompanyTable WHERE Company = @company ";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@company", SqlDbType.VarChar);
            Command.Parameters["@company"].Value = companyName;

            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRow;
        }
    }
}