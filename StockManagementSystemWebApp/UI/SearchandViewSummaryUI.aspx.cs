using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace StockManagementSystemWebApp.UI
{
    public partial class SearchandViewSummaryUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        ItemManager aItemManager = new ItemManager();
        ViewSummaryManager aViewSummaryManager = new ViewSummaryManager();
        CatagoryManager aCatagoryManager = new CatagoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfButton.Enabled = false;
            if (!IsPostBack)
            {
                List<Catagory> catagories = aCatagoryManager.GetAllatagories();
                catagoryDropDownList.DataSource = catagories;
                catagoryDropDownList.DataValueField = "CatagoryId";
                catagoryDropDownList.DataTextField = "CatagoryName";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, new ListItem("Select", "0"));

                companyDropDownList.DataSource = aCompanyManager.GetAllCompanies(); ;
                companyDropDownList.DataValueField = "CompanyId";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0 && catagoryDropDownList.SelectedIndex == 0)
            {
                //Response.Redirect("SearchandViewSummaryUI.aspx");
                messageLabel.Text = "Select Either Company or Catagory or Both.";
                dataTable.DataSource = null;
                dataTable.DataBind();
            }
            else
            {
                PopulateGridView(catagoryDropDownList, companyDropDownList);
                companyDropDownList.SelectedValue = null;
                catagoryDropDownList.SelectedValue = null;
            }
        }

        private void PopulateGridView(DropDownList dropDownList, DropDownList companyDropDownList1)
        {
            List<ItemViewModel> items = aViewSummaryManager.GetAllItems(dropDownList, companyDropDownList1);
            dataTable.DataSource = items;
            dataTable.DataBind();
            if (dataTable.Rows.Count > 0)
            {
                dataTable.UseAccessibleHeader = true;
                dataTable.HeaderRow.TableSection = TableRowSection.TableHeader;
                messageLabel.Text = "Data found";
                pdfButton.Enabled = true;

            }
            else
            {
                messageLabel.Text = "No data Found";
            }

        }
        //private void PopulateGridView(DropDownList catagoryDropDownList1, DropDownList companyDropDownList1)
        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Sumamry.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            pdfPanel.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}