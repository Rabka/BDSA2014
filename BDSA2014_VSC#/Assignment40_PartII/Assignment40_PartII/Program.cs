using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load CSV...
            Respiratory respiratory = CSVimporter.ImportCSV();
            NorthWind northWind = new NorthWind(respiratory);

            northWind.newOrderEvent += subscription;
            Console.WriteLine("Adding an order to Denmark.");
            northWind.AddOrder(DateTime.Now, "testName", "testAddress", "testCity", "testRegion", "2300", "Denmark");

            //Write list with name of first 5 products
            Console.WriteLine("");
            Console.WriteLine("First 5 products");
            northWind.Products().Take(5).ToList().ForEach(x => Console.WriteLine(x.ProductName));
            Console.WriteLine("");
            Console.WriteLine("Counting of orders by shipping country. Output by descending count");

            //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
            Dictionary<string, int> countryCount = new Dictionary<string, int>();
            northWind.Orders().GroupBy(x => x.ShipCountry).Select(x => x.First()).ToList()
                .ForEach(x => countryCount.Add(x.ShipCountry,northWind.Orders().Select(a => a.ShipCountry).Where(c => c == x.ShipCountry).Count()));
            countryCount.Keys.ToList().OrderBy(x => countryCount[x]).ToList().ForEach(x => Console.WriteLine(x + " : "+ countryCount[x]));
            Console.ReadLine();
        }

        public static void subscription(Order order)
        {
            Console.WriteLine("Order added at: " + order.OrderDate.ToShortDateString());
        }
    }
}
