using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;

namespace StockManagementSystemWebApp.BLL
{
    public class AdminManager
    {
        AdminGateway aAdminGateway = new AdminGateway();
        public bool IsAdminName(string name)
        {
            return aAdminGateway.CheckName(name);
        }

        public bool IsAdminPasswordExist(string password)
        {
            return aAdminGateway.CheckPassword(password);
        }
    }
}