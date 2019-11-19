using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ViewSalesGateway : Gateway
    {
        public List<ItemViewModel> GetItemByDate(DateTime fromDate, DateTime toDate)
        {
            Query = "SELECT Item,SUM(Quantity) AS Total FROM StockOutTable WHERE TimeStamp>= @from AND TimeStamp<=@to AND Condition='Sell' GROUP BY Item";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@from", fromDate);
            Command.Parameters.AddWithValue("@to", toDate);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemViewModel> items = new List<ItemViewModel>();

            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();
                aItemViewModel.ItemName = Reader["Item"].ToString();
                aItemViewModel.Quantity = Convert.ToInt32(Reader["Total"]);//declared sum(quantity) as total
                items.Add(aItemViewModel);
            }
            Connection.Close();

            return items;
        }
    }
}