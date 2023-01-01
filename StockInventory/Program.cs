using System;

namespace StockInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StockAccountManagement stockAccountManagement = new StockAccountManagement();

            string stockFilePath = @"E:\RFP 232 BATCH\JSON\StockInventory\Stock.json";
            stockAccountManagement.ReadStockJsonFile(stockFilePath);
            string customerFilePath = @"E:\RFP 232 BATCH\JSON\StockInventory\Customer.json";
            stockAccountManagement.ReadCustomerJsonFile(customerFilePath);
            stockAccountManagement.BuyStock("Google");
            stockAccountManagement.SellStock("Google");
            stockAccountManagement.WriteToStockJsonFile(stockFilePath);
            stockAccountManagement.WriteToStockJsonFile(customerFilePath);
        }
    }
}
