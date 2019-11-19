using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        StockInManager aStockInManager = new StockInManager();
        StockOutManager aStockOutManager = new StockOutManager();
        DataTable aDataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["Records"] == null)
                {
                    FillCompanyDropdownList();
                    aDataTable.Columns.Add("Item");
                    aDataTable.Columns.Add("Company");
                    aDataTable.Columns.Add("Quantity");
                    ViewState["Records"] = aDataTable;
                }

            }
            sellButton.Enabled = false;
            damageButton.Enabled = false;
            lostButton.Enabled = false;
        }

        private void FillCompanyDropdownList()
        {
            companyDropDownList.DataSource = aCompanyManager.GetAllCompanies(); ;
            companyDropDownList.DataValueField = "CompanyId";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, new ListItem("Select", "0"));
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        protected void addButton_Click(object sender, EventArgs e)
        {

            if (companyDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select a company";
            }
            else if (itemDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select an Item";
            }
            else
            {
                if (Convert.ToInt32(availableQuantityTextBox.Text) >= Convert.ToInt32(stockOutQuantityTextBox.Text))
                {
                    aDataTable = (DataTable)ViewState["Records"];
                    aDataTable.Rows.Add(itemDropDownList.SelectedItem.Text, companyDropDownList.SelectedItem.Text, stockOutQuantityTextBox.Text);
                    stockOutGridView.DataSource = aDataTable;
                    stockOutGridView.DataBind();
                    messageLabel.Text = "";
                    sellButton.Enabled = true;
                    damageButton.Enabled = true;
                    lostButton.Enabled = true;
                }
                else
                {
                    messageLabel.Text = "Insufficient Product in stock";
                }
            }


        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            aStockOutManager.StockOutItemBySell(stockOutGridView);
            Clear();
            stockOutGridView.DataSource = "";
            stockOutGridView.DataBind();
            Response.Redirect("StockOutUI.aspx");
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            aStockOutManager.StockOutItemBySDamage(stockOutGridView);
            Clear();
            stockOutGridView.DataSource = "";
            stockOutGridView.DataBind();
            Response.Redirect("StockOutUI.aspx");


        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            aStockOutManager.StockOutItemByLost(stockOutGridView);
            Clear();
            stockOutGridView.DataSource = "";
            stockOutGridView.DataBind();
            Response.Redirect("StockOutUI.aspx");
        }

        protected void Clear()
        {
            stockOutQuantityTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            companyDropDownList.SelectedValue = null;
            itemDropDownList.SelectedValue = null;
            reorderLevelTextBox.Text = "";
        }

    }
}