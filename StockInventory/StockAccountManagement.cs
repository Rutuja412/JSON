using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace StockInventory
{
    public class StockAccountManagement
    {
        double amount = 1000;
        List<StockDetails> stock = new List<StockDetails>();
        List<StockDetails> customer = new List<StockDetails>();
        public void ReadStockJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.stock = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            Console.WriteLine("StockName  StockPrice  NoOfShares");
            foreach (var content in stock)
            {
                Console.WriteLine(content.StockName + "   " + content.StockPrice + "   " + content.NoOfShares);
            }
        }
        public void ReadCustomerJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.customer = JsonConvert.DeserializeObject<List<StockDetails>>(json);
            Console.WriteLine("\nStockName  StockPrice  NoOfShares");
            foreach (var content in customer)
            {
                Console.WriteLine(content.StockName + "   " + content.StockPrice + "   " + content.NoOfShares);
            }
        }
        public void BuyStock(string name)
        {
            foreach (var data in stock)
            {
                int count = 0;
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter required stocks you need to buy");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks * data.StockPrice <= amount && noOfStocks <= data.NoOfShares)
                    {
                        StockDetails details = new StockDetails()
                        {
                            StockName = data.StockName,
                            StockPrice = data.StockPrice,
                            NoOfShares = noOfStocks
                        };
                        data.NoOfShares -= noOfStocks;
                        amount -= data.StockPrice * noOfStocks;
                        foreach (var account in customer)
                        {
                            if (account.StockName.Equals(name))
                            {
                                count++;
                            }
                        }
                        if (count == 1)
                        {
                            data.NoOfShares += noOfStocks;
                        }
                        else
                        {
                            customer.Add(details);
                        }
                    }
                }
            }
        }
        public void SellStock(string name)
        {
            foreach (var data in customer)
            {
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter number stocks you want to sell");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks <= data.NoOfShares)
                    {
                        data.NoOfShares -= noOfStocks;
                        amount += data.StockPrice * noOfStocks;
                        foreach (var account in stock)
                        {
                            if (account.StockName.Equals(name))
                            {
                                data.NoOfShares += noOfStocks;
                                return;
                            }
                        }
                    }
                }
            }
        }
        public void WriteToStockJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(stock);
            File.WriteAllText(filePath, json);
        }
        public void WriteToCustomerJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(customer);
            File.WriteAllText(filePath, json);
        }
    }
}