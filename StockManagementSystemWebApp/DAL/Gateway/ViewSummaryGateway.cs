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
    public class ViewSummaryGateway:Gateway
    {
        public List<ItemViewModel> GetAllItems(DropDownList catagoryDropDownList, DropDownList companyDropDownList)
        {
            if (companyDropDownList.SelectedIndex > 0 && catagoryDropDownList.SelectedIndex > 0)
            {
                Query =
                "SELECT * FROM ItemTable INNER JOIN CatagoryTable ON ItemTable.CatagoryId = CatagoryTable.Id INNER JOIN CompanyTable ON ItemTable.CompanyId = CompanyTable.Id WHERE CompanyId = '" + companyDropDownList.SelectedItem.Value + "' AND CatagoryId = '" +
                catagoryDropDownList.SelectedItem.Value + "'";
            }
            else if (companyDropDownList.SelectedIndex > 0)
            {
                Query =
                "SELECT * FROM ItemTable INNER JOIN CatagoryTable ON ItemTable.CatagoryId = CatagoryTable.Id INNER JOIN CompanyTable ON ItemTable.CompanyId = CompanyTable.Id WHERE CompanyId = '" + companyDropDownList.SelectedItem.Value + "'";
            }
            else if (catagoryDropDownList.SelectedIndex > 0)
            {
                Query = "SELECT * FROM ItemTable INNER JOIN CatagoryTable ON ItemTable.CatagoryId = CatagoryTable.Id INNER JOIN CompanyTable ON ItemTable.CompanyId = CompanyTable.Id WHERE CatagoryId = '" +
                catagoryDropDownList.SelectedItem.Value + "'";
            }

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            List<ItemViewModel> items = new List<ItemViewModel>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();
                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                aItemViewModel.CatagoryName = Reader["Catagory"].ToString();
                aItemViewModel.CompanyName = Reader["Company"].ToString();
                aItemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"].ToString());
                aItemViewModel.Quantity = Convert.ToInt32(Reader["AvailableQuantity"].ToString());
                items.Add(aItemViewModel);
            }
            Connection.Close();
            Reader.Close();
            return items;
        }
    }
}