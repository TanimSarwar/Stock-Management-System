using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.BLL
{
    public class CatagoryManager
    {
        CatagoryGateway aCatagoryGateway = new CatagoryGateway();
        public string Save(Catagory aCatagory)
        {
            if (aCatagoryGateway.IsCatagoryExist(aCatagory))
            {
                return "Catagory Already Exists.";
            }
            else
            {
                int rowAffected = aCatagoryGateway.Save(aCatagory);

                if (rowAffected > 0)
                {
                    return "Catagory Saved.";
                }
                return "Catagory Not Saved.";
            }
        }

        public List<Catagory> GetAllatagories()
        {
            return aCatagoryGateway.GetAllCatagories();
        }

        public string Update(Catagory aCatagory)
        {
            if (aCatagoryGateway.IsCatagoryExist(aCatagory))
            {
                return "Catagory Already Exist";
            }
            else
            {
                int rowAffected = aCatagoryGateway.Update(aCatagory);

                if (rowAffected > 0)
                {
                    return "Catagory Name Updated.";
                }
                return "Catagory Not Updated.";
            }
           
          }
        }
    }
