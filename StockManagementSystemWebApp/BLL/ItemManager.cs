using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class ItemManager
    {
        ItemGateway aItemGateway = new ItemGateway();
        public string Save(ItemViewModel aItemViewModel)
        {
            if (aItemGateway.IsItemExist(aItemViewModel.ItemName))
            {
                return "Item Already Exists";
            }
            int rowAffected = aItemGateway.Save(aItemViewModel);
            if (rowAffected > 0)
            {
                return "Item Saved";
            }
            return "Item Not Saved";
        }

        public List<ItemViewModel> GetAllItems()
        {
            return aItemGateway.GetAllItems();
        }
    }
}