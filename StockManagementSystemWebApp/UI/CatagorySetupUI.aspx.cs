using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class CatagorySetupUI : System.Web.UI.Page
    {
        CatagoryManager aCatagoryManager = new CatagoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }


        private void PopulateGridView()
        {
            List<Catagory> catagories = aCatagoryManager.GetAllatagories();
            dataTable.DataSource = catagories;
            dataTable.DataBind();
            dataTable.UseAccessibleHeader = true;
            dataTable.HeaderRow.TableSection = TableRowSection.TableHeader;
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
                if (saveButton.Text == "Update")
                {
                    Catagory aCatagory = new Catagory();
                    aCatagory.CatagoryName = catagoryTextBox.Text;
                    aCatagory.CatagoryId = Convert.ToInt32(idStoreHiddenField.Value);
                    messageLabel.Text = aCatagoryManager.Update(aCatagory);
                    PopulateGridView();
                    saveButton.Text = "Save";

                }
                else
                {
                    Catagory aCatagory = new Catagory();
                    aCatagory.CatagoryName = catagoryTextBox.Text;
                    messageLabel.Text = aCatagoryManager.Save(aCatagory);
                    PopulateGridView();
                }
            catagoryTextBox.Text = "";
            PopulateGridView();
        }



        protected void catagoryGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(dataTable,
                    "Select$" + e.Row.DataItemIndex);
            }
        }

        protected void catagoryGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dataTable.SelectedRow;
            if (row != null)
            {
                HiddenField aHiddenField = (HiddenField)row.FindControl("idHiddenField");
                idStoreHiddenField.Value = aHiddenField.Value;
                Label name = (Label)row.FindControl("Name");


                catagoryTextBox.Text = name.Text;
                saveButton.Text = "Update";
            }
        }
    }
}