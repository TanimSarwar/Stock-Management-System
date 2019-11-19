using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        StockInManager aStockInManager = new StockInManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCompanyDropdownList();
            }

        }
        private void FillCompanyDropdownList()
        {
            //List<Company> companies = aCompanyManager.GetAllCompanies();
            companyDropDownList.DataSource = aCompanyManager.GetAllCompanies(); ;
            companyDropDownList.DataValueField = "CompanyId";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<Item> items = aItemManager.GetAllItemByCompanyId(companyId);
            int companyId = Convert.ToInt32(companyDropDownList.SelectedItem.Value);
            itemDropDownList.DataSource = aStockInManager.GetAllItemByCompanyId(companyId);
            itemDropDownList.DataValueField = "ItemId";
            itemDropDownList.DataTextField = "ItemName";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemViewModel aItemViewModel = new ItemViewModel();
            int ItemId = Convert.ToInt32(itemDropDownList.SelectedItem.Value);
            aItemViewModel = aStockInManager.GetItemById(ItemId);
            reorderLevelTextBox.Text = aItemViewModel.ReorderLevel.ToString();
            availableQuantityTextBox.Text = aItemViewModel.Quantity.ToString();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0 && itemDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select a Company and an Item.";

            }
            else if (companyDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select a Company.";
                //Response.Redirect("StockInUI.aspx");
            }
            else if (itemDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select an Item.";
                //Response.Redirect("StockInUI.aspx");
            }
            else
            {
                ItemViewModel aItemViewModel = new ItemViewModel();
                aItemViewModel.Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                aItemViewModel.ItemName = itemDropDownList.SelectedItem.Text;
                messageLabel.Text = aStockInManager.SaveQuantity(aItemViewModel);
                Clear();
            }


        }

        private void Clear()
        {
            stockInQuantityTextBox.Text = "";
            companyDropDownList.SelectedIndex = 0;
            itemDropDownList.SelectedIndex = 0;
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
        }
    }
}