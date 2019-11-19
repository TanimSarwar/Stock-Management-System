using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class Gateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBConnection"].ConnectionString;

        public SqlCommand Command { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}