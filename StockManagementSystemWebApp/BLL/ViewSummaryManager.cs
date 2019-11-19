using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class ViewSummaryManager
    {
        ViewSummaryGateway aViewSummaryGateway = new ViewSummaryGateway();
        public List<ItemViewModel> GetAllItems(DropDownList catagoryDropDownList, DropDownList companyDropDownList)
        {
            return aViewSummaryGateway.GetAllItems(catagoryDropDownList, companyDropDownList);
        }
    }
}