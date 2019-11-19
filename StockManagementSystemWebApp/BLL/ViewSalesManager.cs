using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class ViewSalesManager
    {
        ViewSalesGateway aViewSalesGateway = new ViewSalesGateway();
        public List<ItemViewModel> GetItemByDate(DateTime fromDate, DateTime toDate)
        {
            return aViewSalesGateway.GetItemByDate(fromDate, toDate);
        }
    }
}