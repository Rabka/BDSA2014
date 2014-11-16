using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Assignment40_1.Model;
using Assignment40_1.Properties;

namespace Assignment40_1
{
    public static class CSVimporter
    {
        /// <summary>
        /// This class takes strings from Resources and makes data classes from them.
        /// then it instantiate a Respiratory with the new data classes and returns it.
        /// </summary>
        /// <returns>A Respiratory contaning data classes</returns>
        public static CSVRespiratory ImportCSV(string _categories, string _products, string _orders, string _orderDetails)
        {
            var categories = new Dictionary<string, Categories>();
            var products = new Dictionary<string, Products>();
            var orders = new Dictionary<string, Orders>();
            var orderDetails = new Dictionary<string, Order_Details>();

            var path = AppDomain.CurrentDomain.BaseDirectory;

            string[] catLines = _categories.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 1; k < catLines.Length; k++)
            {
                string[] catCol = catLines[k].Split(';');
                categories.Add(catCol[0], new Categories(int.Parse(catCol[0]), catCol[1], catCol[2]));
            }

            string[] proLines = _products.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 1; k < proLines.Length; k++)
            {
                string[] proCol = proLines[k].Split(';');
                products.Add(proCol[0], new Products(int.Parse(proCol[0]), proCol[1], int.Parse(proCol[2]), categories[proCol[3]], proCol[4], decimal.Parse(proCol[5].Replace(".", ",")), short.Parse(proCol[6]), short.Parse(proCol[7]), short.Parse(proCol[8]), proCol[9] == "1" ? true : false));
            }
            foreach (Categories category in categories.Values)
            {
                category.Products = products.Values.Select(x =>x).Where(x => x.CategoryID == category.CategoryID).ToList();
            }

            string[] ordLines = _orders.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 1; k < ordLines.Length; k++)
            {
                string[] ordCol = ordLines[k].Split(';');
                DateTime? d = null;
                DateTime d2;
                if (DateTime.TryParse(ordCol[5], out d2))
                    d = d2;
                orders.Add(ordCol[0], new Orders(int.Parse(ordCol[0]), ordCol[1], int.Parse(ordCol[2]), DateTime.Parse(ordCol[3]), DateTime.Parse(ordCol[4]), d, int.Parse(ordCol[6]), decimal.Parse(ordCol[7].Replace(".", ",")), ordCol[8], ordCol[9], ordCol[10], ordCol[11], ordCol[12], ordCol[13]));
            }

            string[] detLines = _orderDetails.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 1; k < detLines.Length; k++)
            {
                string[] detCol = detLines[k].Split(';');
                orderDetails.Add(k.ToString(), new Order_Details(orders[detCol[0]], products[detCol[1]], decimal.Parse(detCol[2].Replace(".", ",")), short.Parse(detCol[3]), float.Parse(detCol[4].Replace(".", ","))));
            }
            foreach (Products product in products.Values)
            {
                product.Order_Details = orderDetails.Values.Select(x => x).Where(x => x.ProductID == product.ProductID).ToList();
            }
            foreach (Orders order in orders.Values)
            {
                order.Order_Details = orderDetails.Values.Select(x => x).Where(x => x.OrderID == order.OrderID).ToList();
            }



            Categories[] categoriesArray = categories.Values.ToArray();
            Products[] productsArray = products.Values.ToArray();
            Orders[] ordersArray = orders.Values.ToArray();

            return new CSVRespiratory(productsArray, categoriesArray, ordersArray);
        }
    }
}
