using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;

namespace StockManagementSystemWebApp.DAL.Model
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int CatagoryId { get; set; }
        public int CompanyId { get; set; }
        public int Quantity { get; set; }
        public int StockOutQuantity { get; set; }
        public string CatagoryName { get; set; }
        public string CompanyName { get; set; }
    }
}