﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Assignment40_PartIII.Properties;
using System.Data.Entity;
using Assignment40_PartIII.Model;

namespace Assignment40_PartIII
{
    /// <summary>
    /// The main class using the system made after Part II - C# specifications.
    /// And solutions for following requirements:
    /// - Add a new order [the subscription to the event should report this]
    /// - Write a list with the name of the first 5 products [use LINQ]
    /// - Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Instantiating Respiratory and NorthWind classes to use in solutions.
        /// And runs solutions.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {          
            Console.WriteLine("Attaching NORTHWND.MDF");
            using (NORTHWNDEntities1 db = new NORTHWNDEntities1())
            {
                Console.WriteLine("Connecting NORTHWND.MDF");
                db.Database.Connection.Open();

                Console.WriteLine("Connected");
                IRespiratory respiratory = new Respiratory(db);
                NorthWind northWind = new NorthWind(respiratory);

                Console.WriteLine("Preparing database meta data");
                //Dummy query
                northWind.Products().Take(0);

                Console.WriteLine("Ready");
               // ReportingModule reportingModule = new ReportingModule(northWind);
                //IList<OrdersByTotalPriceDto> reportedOrders = reportingModule.TopOrdersByTotalPrice(5).Data;
                northWind.newOrderEvent += subscription;

                Console.WriteLine("Adding an order to Denmark.");
                northWind.AddOrder(DateTime.Now, "testName", "testAddress", "testCity", "testRegion", "2300", "Denmark");

                //Write list with name of first 5 products
                First5Products(northWind);

                //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
                OrdersByShippingCountry(northWind);
                Console.WriteLine("Finished");

                Console.ReadLine();
            }          
        }

        /// <summary>
        /// Uses linq to find the first 5 products in the NorthWind class
        /// </summary>
        /// <param name="northWind">A NorthWind class</param>
        public static void First5Products(NorthWind northWind)
        {
            Console.WriteLine("");
            Console.WriteLine("First 5 products");
            //Write list with name of first 5 products
            northWind.Products().Take(5).ToList().ForEach(x => WriteLineLock(x.ProductName));
        }

        /// <summary>
        /// Uses linq to find the "Counting of orders by shipping country. Output by descending count" in the NorthWind class
        /// </summary>
        /// <param name="northWind">A NorthWind class</param>
        public static void OrdersByShippingCountry(NorthWind northWind)
        {
            Console.WriteLine("");
            Console.WriteLine("Counting of orders by shipping country. Output by descending count");
            //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
            Dictionary<string, int> countryCount = new Dictionary<string, int>();
            northWind.Orders().ToList().GroupBy(x => x.ShipCountry).Select(x => x.First()).ToList()
                .ForEach(x => countryCount.Add(x.ShipCountry, northWind.Orders().Select(a => a.ShipCountry).Where(c => c == x.ShipCountry).Count()));
            countryCount.Keys.ToList().OrderBy(x => countryCount[x]).ToList().ForEach(x => WriteLineLock(x + " : " + countryCount[x]));
        }


        public static List<String> ConsoleLock = new List<string>();
        /// <summary>
        /// To make it posible to unit test what is writen i the console by the solutions.
        /// </summary>
        /// <param name="s">The string to be writen i console</param>
        public static void WriteLineLock(String s)
        {
            ConsoleLock.Add(s);
            Console.WriteLine(s);
        }

        /// <summary>
        /// A event for the NorthWind to run eath time a new event is added.
        /// </summary>
        /// <param name="order">The order ther is added</param>
        public static void subscription(Orders order)
        {
            DateTime dt = order.OrderDate.Value;
            Console.WriteLine("Order added at: " + dt.ToShortDateString());
        }
        
    }
}