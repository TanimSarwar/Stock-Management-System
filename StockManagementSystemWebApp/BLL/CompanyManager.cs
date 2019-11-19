using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class CompanyManager
    {
        ComapanyGateway aComapanyGateway = new ComapanyGateway();
        public string Save(Company aCompany)
        {
            if (aComapanyGateway.IsCompanyExist(aCompany.CompanyName))
            {
                return "Company Already Exists.";
            }
            int rowAffected = aComapanyGateway.Save(aCompany);
            if (rowAffected > 0)
            {
                return "Company Saved.";
            }
            return "Company Not Saved.";
        }

        public List<Company> GetAllCompanies()
        {
            return aComapanyGateway.GetAllCompanies();
        }


    }
}