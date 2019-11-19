using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL.Gateway;

namespace StockManagementSystemWebApp.BLL
{
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway = new StockOutGateway();
        public void StockOutItemBySell(GridView dataTable)
        {
            aStockOutGateway.StockOutItemBySell(dataTable);
        }

        public void StockOutItemBySDamage(GridView dataTable)
        {
            aStockOutGateway.StockOutItemByDamage(dataTable);

        }

        public void StockOutItemByLost(GridView dataTable)
        {
            aStockOutGateway.StockOutItemByLost(dataTable);
        }
    }
}