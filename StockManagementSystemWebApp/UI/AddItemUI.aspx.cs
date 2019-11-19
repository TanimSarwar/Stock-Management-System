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
    public partial class AddItemUI : System.Web.UI.Page
    {
        CatagoryManager aCatagoryManager = new CatagoryManager();
        CompanyManager aCompanyManager = new CompanyManager();
        ItemManager aItemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Catagory> catagories = aCatagoryManager.GetAllatagories();
                catagoryDropDownList.DataSource = catagories;
                catagoryDropDownList.DataValueField = "CatagoryId";
                catagoryDropDownList.DataTextField = "CatagoryName";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, new ListItem("Select", "0"));


                List<Company> companies = aCompanyManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select", "0"));

            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (catagoryDropDownList.SelectedIndex == 0 && companyDropDownList.SelectedIndex == 0 )
            {
                messageLabel.Text = "Select a Catagory and a Company.";
                
            }
            else if (catagoryDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select a Catagory.";
            }
            else if (companyDropDownList.SelectedIndex == 0)
            {
                messageLabel.Text = "Select a Company.";
            }
            else
            {
                ItemViewModel aItemViewModel = new ItemViewModel();
                aItemViewModel.ItemName = itemNameTextBox.Text;
                aItemViewModel.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                aItemViewModel.CatagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                aItemViewModel.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                messageLabel.Text = aItemManager.Save(aItemViewModel);
                Clear();
            }
            

        }

        private void Clear()
        {
            itemNameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
            catagoryDropDownList.SelectedIndex = 0;
            companyDropDownList.SelectedIndex = 0;

        }
    }
}