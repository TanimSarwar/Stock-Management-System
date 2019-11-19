using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class AdminGateway: Gateway
    {

        public bool CheckName(string name)
        {
            Query = "SELECT * FROM AdminTable WHERE Name=@name";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Name", name);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }

        public bool CheckPassword(string password)
        {
            Query = "SELECT * FROM AdminTable WHERE Password=@password";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@password", password);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }
    }
}