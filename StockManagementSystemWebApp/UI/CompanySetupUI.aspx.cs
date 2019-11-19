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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            List<Company> companies = aCompanyManager.GetAllCompanies();
            dataTable.DataSource = companies;
            dataTable.DataBind();
            dataTable.UseAccessibleHeader = true;
            dataTable.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            aCompany.CompanyName = companyTextBox.Text;
            messageLabel.Text = aCompanyManager.Save(aCompany);
            PopulateGridView();
        }

    }
}