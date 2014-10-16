using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Assignment40_PartII.Properties;

namespace Assignment40_PartII
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program P = new Program();

            //Load CSV...
            Respiratory respiratory = CSVimporter.ImportCSV();
            NorthWind northWind = new NorthWind(respiratory);

            northWind.newOrderEvent += subscription;
            Console.WriteLine("Adding an order to Denmark.");
            northWind.AddOrder(DateTime.Now, "testName", "testAddress", "testCity", "testRegion", "2300", "Denmark");

            //Write list with name of first 5 products
            First5Products(northWind);

            //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
            OrdersByShippingCountry(northWind);

            Console.ReadLine();
        }

        public static void First5Products(NorthWind northWind)
        {
            //Write list with name of first 5 products
            Console.WriteLine("");
            Console.WriteLine("First 5 products");
            northWind.Products().Take(5).ToList().ForEach(x => WriteLineLock(x.ProductName));
        }

        public static void OrdersByShippingCountry(NorthWind northWind)
        {
            Console.WriteLine("");
            Console.WriteLine("Counting of orders by shipping country. Output by descending count");
            //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
            Dictionary<string, int> countryCount = new Dictionary<string, int>();
            northWind.Orders().GroupBy(x => x.ShipCountry).Select(x => x.First()).ToList()
                .ForEach(x => countryCount.Add(x.ShipCountry, northWind.Orders().Select(a => a.ShipCountry).Where(c => c == x.ShipCountry).Count()));
            countryCount.Keys.ToList().OrderBy(x => countryCount[x]).ToList().ForEach(x => WriteLineLock(x + " : " + countryCount[x]));
        }

        public static List<String> ConsoleLock = new List<string>();

        public static void WriteLineLock(String s)
        {
            ConsoleLock.Add(s);
            Console.WriteLine(s);
        }

        public static void subscription(Order order)
        {
            Console.WriteLine("Order added at: " + order.OrderDate.ToShortDateString());
        }
    }
}
