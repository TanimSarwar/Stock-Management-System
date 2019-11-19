using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class StockInManager
    {
        StockInGateway aStockInGateway = new StockInGateway();
        public string SaveQuantity(ItemViewModel aItemViewModel)
        {
            int rowAffected = aStockInGateway.SaveQuantity(aItemViewModel);
            if (rowAffected > 0)
            {
                return "Quantity Updated";
            }
            return "Quantity Not Updated";
        }
        public List<ItemViewModel> GetAllItemByCompanyId(int id)
        {
            return aStockInGateway.GetAllItemByCompanyId(id);
        }

        public ItemViewModel GetItemById(int itemId)
        {
            return aStockInGateway.GetAllItemById(itemId);
        }
    }
}