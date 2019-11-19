using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class StockInGateway : Gateway
    {
        public int SaveQuantity(ItemViewModel aItemViewModel)
        {
            Query = "UPDATE ItemTable SET AvailableQuantity=AvailableQuantity+@availableQuantity WHERE ItemName = @item";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@availableQuantity", SqlDbType.Int);
            Command.Parameters["@availableQuantity"].Value = aItemViewModel.Quantity;
            Command.Parameters.Add("@item", SqlDbType.VarChar);
            Command.Parameters["@item"].Value = aItemViewModel.ItemName;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<ItemViewModel> GetAllItemByCompanyId(int id)
        {
            Query = "SELECT * FROM ItemTable WHERE CompanyId=@companyId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@companyId", SqlDbType.Int);
            Command.Parameters["@companyId"].Value = id;
            Connection.Open();
            List<ItemViewModel> items = new List<ItemViewModel>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();
                aItemViewModel.ItemId = Convert.ToInt32(Reader["Id"].ToString());
                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                items.Add(aItemViewModel);
            }
            Connection.Close();
            Reader.Close();
            return items;
        }

        public ItemViewModel GetAllItemById(int itemId)
        {
            Query = "SELECT * FROM ItemTable WHERE Id=@id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@id", SqlDbType.Int);
            Command.Parameters["@id"].Value = itemId;
            Connection.Open();
            //List<ItemViewModel> items = new List<ItemViewModel>();
            Reader = Command.ExecuteReader();
            ItemViewModel aItemViewModel = null;
            if (Reader.HasRows)
            {
                aItemViewModel = new ItemViewModel();
                Reader.Read();
                aItemViewModel.ItemId = Convert.ToInt32(Reader["Id"].ToString());
                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                aItemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"].ToString());
                aItemViewModel.Quantity = Convert.ToInt32(Reader["AvailableQuantity"].ToString());
            }

            Connection.Close();
            Reader.Close();
            return aItemViewModel;
        }
    }
}