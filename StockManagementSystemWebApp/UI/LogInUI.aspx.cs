using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL;

namespace StockManagementSystemWebApp.UI
{
    public partial class Index : System.Web.UI.Page
    {
        AdminManager aAdminManager = new AdminManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string name = login__username.Value;
            string password = login__password.Value;
            bool isExistAdmin = aAdminManager.IsAdminName(name);
            bool isExistAdminpascode = aAdminManager.IsAdminPasswordExist(password);
            if (isExistAdmin && isExistAdminpascode)
            {
                Response.Redirect("IndexUI.aspx");
            }
            else
            {
                string message = "Wrong User Name or Password";
                messageLabel.Text = message;
            }
            
        }
    }
}