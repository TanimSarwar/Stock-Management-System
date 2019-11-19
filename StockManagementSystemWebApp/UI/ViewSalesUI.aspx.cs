using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;
using StockManagementSystemWebApp.DAL.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace StockManagementSystemWebApp.UI
{
    public partial class ViewSalesUI : System.Web.UI.Page
    {
        ViewSalesManager aViewSalesManager = new ViewSalesManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            pdfButton.Enabled = false;
        }

        protected void searchButton_OnClick(object sender, EventArgs e)
        {
            if (fromTextBox.Text == "" && toTextBox.Text == "")
            {
                messageLabel.Text = "Enter a Valid Range Of Date.";
            }
            else if (fromTextBox.Text == "")
            {
                messageLabel.Text = "Enter a From Date.";
            }
            else if (toTextBox.Text == "")
            {
                messageLabel.Text = "Enter a To Date.";
            }
            else
            {
                DateTime fromDate = Convert.ToDateTime(fromTextBox.Text);
                DateTime toDate = Convert.ToDateTime(toTextBox.Text);

                if (fromDate <= toDate)
                {
                    PopulateGridView(fromDate, toDate);
                    messageLabel.Text = "";
                }
                else
                {
                    messageLabel.Text = "From Date Can Not Be Greter Than To Date.";
                }
            }

        }

        private void PopulateGridView(DateTime fromDate, DateTime toDate)
        {
            List<ItemViewModel> items = aViewSalesManager.GetItemByDate(fromDate, toDate);
            dataTable.DataSource = items;
            dataTable.DataBind();
            if (dataTable.Rows.Count > 0)
            {
                dataTable.UseAccessibleHeader = true;
                dataTable.HeaderRow.TableSection = TableRowSection.TableHeader;
                pdfButton.Enabled = true;
                messageLabel.Text = "Sales Informtaion Found";
            }
            else
            {
                messageLabel.Text = "No Information Found";
            }
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SalesSummary.pdf");
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