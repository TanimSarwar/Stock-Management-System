using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ItemGateway : Gateway
    {
        //To save an Item
        public int Save(ItemViewModel aItemViewModel)
        {
            Query = "INSERT INTO ItemTable(ItemName,ReorderLevel,CatagoryId, CompanyId,AvailableQuantity)VALUES (@item,@reorder,@catagoryId,@companyId,@availableQuantity)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@item", SqlDbType.VarChar);
            Command.Parameters["@item"].Value = aItemViewModel.ItemName;
            Command.Parameters.Add("@reorder", SqlDbType.Int);
            Command.Parameters["@reorder"].Value = aItemViewModel.ReorderLevel;
            Command.Parameters.Add("@catagoryId", SqlDbType.Int);
            Command.Parameters["@catagoryId"].Value = aItemViewModel.CatagoryId;
            Command.Parameters.Add("@companyId", SqlDbType.Int);
            Command.Parameters["@companyId"].Value = aItemViewModel.CompanyId;
            Command.Parameters.Add("@availableQuantity", SqlDbType.Int);
            Command.Parameters["@availableQuantity"].Value = aItemViewModel.Quantity;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        //To check if an item exist, before saving it
        public bool IsItemExist(string itemName)
        {
            Query = "SELECT * FROM ItemTable WHERE ItemName =@item";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@item", SqlDbType.VarChar);
            Command.Parameters["@item"].Value = itemName;

            Connection.Open();
            Reader = Command.ExecuteReader();

            bool hasRow = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRow;

        }
        //To show the items on gridview or dropdownlist
        public List<ItemViewModel> GetAllItems()
        {
            Query = "SELECT * FROM ItemTable";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            List<ItemViewModel> items = new List<ItemViewModel>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();
                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                aItemViewModel.ItemId = Convert.ToInt32(Reader["Id"].ToString());
                items.Add(aItemViewModel);
            }
            Connection.Close();
            Reader.Close();
            return items;
        }
    }
}