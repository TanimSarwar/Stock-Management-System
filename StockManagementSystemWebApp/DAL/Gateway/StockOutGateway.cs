using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class StockOutGateway : Gateway
    {
        public void StockOutItemBySell(GridView dataTable)
        {
            foreach (GridViewRow stockOutGirdViewRow in dataTable.Rows)
            {
                Connection.Open();
                int quantity = Convert.ToInt32(stockOutGirdViewRow.Cells[3].Text);
                Query =
                    "INSERT INTO StockOutTable( Item,Company,Quantity,Condition,Timestamp) VALUES(@item,@company,@quantity,@condition,GETDATE())";
                //Query = "INSERT INTO StockOutTable (Item, Company, Quantity, Condition, TimeStamp) VALUES ('" +
                //stockOutGirdViewRow.Cells[1].Text + "','" + stockOutGirdViewRow.Cells[2].Text + "','" + quantity + "','Sell',GETDATE())";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.Add("@item", SqlDbType.VarChar);
                Command.Parameters["@item"].Value = stockOutGirdViewRow.Cells[1].Text;
                Command.Parameters.Add("@company", SqlDbType.VarChar);
                Command.Parameters["@company"].Value = stockOutGirdViewRow.Cells[2].Text;
                Command.Parameters.Add("@quantity", SqlDbType.Int);
                Command.Parameters["@quantity"].Value = quantity;
                Command.Parameters.Add("@condition", SqlDbType.VarChar);
                Command.Parameters["@condition"].Value = "Sell";
                //Command.Parameters.Add("@timeStamp", SqlDbType.DateTime);
                //Command.Parameters["@timeStamp"].Value = "GETDATE()";

                Command.ExecuteNonQuery();
                Connection.Close();
                QuantityUpdate(stockOutGirdViewRow);
            }
        }

        public void StockOutItemByDamage(GridView dataTable)
        {
            foreach (GridViewRow stockOutGirdViewRow in dataTable.Rows)
            {
                Connection.Open();
                int quantity = Convert.ToInt32(stockOutGirdViewRow.Cells[3].Text);
                //Query = "INSERT INTO StockOutTable (Item, Company, Quantity, Condition, TimeStamp) VALUES ('" +
                //stockOutGirdViewRow.Cells[1].Text + "','" + stockOutGirdViewRow.Cells[2].Text + "','" + quantity + "','Damage',GETDATE())";
                Query =
                    "INSERT INTO StockOutTable( Item, Company, Quantity, Condition, TimeStamp) VALUES(@item,@company,@quantity,@condition,GETDATE())";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.Add("@item", SqlDbType.VarChar);
                Command.Parameters["@item"].Value = stockOutGirdViewRow.Cells[1].Text;
                Command.Parameters.Add("@company", SqlDbType.VarChar);
                Command.Parameters["@company"].Value = stockOutGirdViewRow.Cells[2].Text;
                Command.Parameters.Add("@quantity", SqlDbType.Int);
                Command.Parameters["@quantity"].Value = quantity;
                Command.Parameters.Add("@condition", SqlDbType.VarChar);
                Command.Parameters["@condition"].Value = "Damage";
                //Command.Parameters.Add("@timeStamp", SqlDbType.DateTime);
                //Command.Parameters["@timeStamp"].Value = "GETDATE()";
                Command.ExecuteNonQuery();
                Connection.Close();
                QuantityUpdate(stockOutGirdViewRow);

            }
        }

        public void StockOutItemByLost(GridView dataTable)
        {
            foreach (GridViewRow stockOutGirdViewRow in dataTable.Rows)
            {
                Connection.Open();
                int quantity = Convert.ToInt32(stockOutGirdViewRow.Cells[3].Text);
                //Query = "INSERT INTO StockOutTable (Item, Company, Quantity, Condition, TimeStamp) VALUES ('" +
                //stockOutGirdViewRow.Cells[1].Text + "','" + stockOutGirdViewRow.Cells[2].Text + "','" + quantity + "','Damage',GETDATE())";
                Query =
                    "INSERT INTO StockOutTable( Item, Company, Quantity, Condition, TimeStamp) VALUES(@item,@company,@quantity,@condition,GETDATE())";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.Add("@item", SqlDbType.VarChar);
                Command.Parameters["@item"].Value = stockOutGirdViewRow.Cells[1].Text;
                Command.Parameters.Add("@company", SqlDbType.VarChar);
                Command.Parameters["@company"].Value = stockOutGirdViewRow.Cells[2].Text;
                Command.Parameters.Add("@quantity", SqlDbType.Int);
                Command.Parameters["@quantity"].Value = quantity;
                Command.Parameters.Add("@condition", SqlDbType.VarChar);
                Command.Parameters["@condition"].Value = "Lost";
                //Command.Parameters.Add("@timeStamp", SqlDbType.DateTime);
                //Command.Parameters["@timeStamp"].Value = "GETDATE()";
                Command.ExecuteNonQuery();
                Connection.Close();
                QuantityUpdate(stockOutGirdViewRow);
            }
        }

        private void QuantityUpdate(GridViewRow stockOutGirdViewRow)
        {
            Connection.Open();
            int quantity = Convert.ToInt32(stockOutGirdViewRow.Cells[3].Text);
            //Query = "UPDATE ItemTable SET AvailableQuantity = AvailableQuantity - '" + quantity + "' WHERE ItemName = '" + stockOutGridViewRow.Cells[1].Text + "'";
            Query = "UPDATE ItemTable SET AvailableQuantity=AvailableQuantity-@Quantity WHERE ItemName=@itemName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@Quantity", SqlDbType.Int);
            Command.Parameters["@Quantity"].Value = quantity;
            Command.Parameters.Add("@itemName", SqlDbType.VarChar);
            Command.Parameters["@itemName"].Value = stockOutGirdViewRow.Cells[1].Text;
            Command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}