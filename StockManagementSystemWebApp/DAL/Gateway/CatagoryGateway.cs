using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class CatagoryGateway:Gateway
    {
        public int Save(Catagory aCatagory)
        {
            Query = "INSERT INTO CatagoryTable(Catagory) VALUES(@catagory)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@catagory", SqlDbType.VarChar);
            Command.Parameters["@catagory"].Value = aCatagory.CatagoryName;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCatagoryExist(Catagory aCatagory)
        {
            Query = "SELECT * FROM CatagoryTable WHERE Catagory= @catagory AND Id<>@id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@catagory", SqlDbType.VarChar);
            Command.Parameters["@catagory"].Value = aCatagory.CatagoryName;
            Command.Parameters.Add("@id", SqlDbType.Int);
            Command.Parameters["@id"].Value = aCatagory.CatagoryId;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRow;
           

        }

        public List<Catagory> GetAllCatagories()
        {
            Query = "SELECT * FROM CatagoryTable";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            List<Catagory> catagories = new List<Catagory>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Catagory aCatagory = new Catagory();
                aCatagory.CatagoryName = Reader["Catagory"].ToString();
                aCatagory.CatagoryId = Convert.ToInt32(Reader["Id"].ToString());

                catagories.Add(aCatagory);
            }
            Connection.Close();
            Reader.Close();
            return catagories;
        }

        public int Update(Catagory aCatagory)
        {
            Query = "UPDATE CatagoryTable SET Catagory=@name WHERE Id=@id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@name", SqlDbType.VarChar);
            Command.Parameters["@name"].Value = aCatagory.CatagoryName;
            Command.Parameters.Add("@id", SqlDbType.Int);
            Command.Parameters["@id"].Value = aCatagory.CatagoryId;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}