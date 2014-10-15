using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    static class CSVimporter
    {
        public static Respiratory ImportCSV()
        {
            var categories = new Dictionary<string, Category>();
            var products = new Dictionary<string, Product>();
            var orders = new Dictionary<string, Order>();
            var orderDetails = new Dictionary<string, OrderDetails>();

            string[] catLines = System.IO.File.ReadAllLines("categories.txt");
            for (int k = 1; k < catLines.Length; k++)
            {
                string[] catCol = catLines[k].Split(';');
                categories.Add(catCol[0], new Category(catCol[1], catCol[2]));
            }

            string[] proLines = System.IO.File.ReadAllLines("products.txt");
            for (int k = 1; k < proLines.Length; k++)
            {
                string[] proCol = proLines[k].Split(';');
                products.Add(proCol[0], new Product(proCol[1], null, categories[proCol[3]], proCol[4], double.Parse(proCol[5]), int.Parse(proCol[6]), int.Parse(proCol[7]), int.Parse(proCol[8]), int.Parse(proCol[9])));
            }

            string[] ordLines = System.IO.File.ReadAllLines("orders.txt");
            for (int k = 1; k < ordLines.Length; k++)
            {
                string[] ordCol = ordLines[k].Split(';');
                DateTime? d = null;
                DateTime d2;
                if (DateTime.TryParse(ordCol[5], out d2))
                    d = d2;
                orders.Add(ordCol[0], new Order(int.Parse(ordCol[0]), null, null, DateTime.Parse(ordCol[3]), DateTime.Parse(ordCol[4]), d, int.Parse(ordCol[6]), double.Parse(ordCol[7]), ordCol[8], ordCol[9], ordCol[10], ordCol[11], ordCol[12], ordCol[13]));
            }

            string[] detLines = System.IO.File.ReadAllLines("order_details.txt");
            for (int k = 1; k < detLines.Length; k++)
            {
                string[] detCol = detLines[k].Split(';');
                orderDetails.Add(k.ToString(), new OrderDetails(orders[detCol[0]], products[detCol[1]], double.Parse(detCol[2]), int.Parse(detCol[3]), double.Parse(detCol[4])));
            }


            Category[] categoriesArray = categories.Values.ToArray();
            Product[] productsArray = products.Values.ToArray();
            Order[] ordersArray = orders.Values.ToArray();

            return new Respiratory(productsArray, categoriesArray, ordersArray);
        }
    }
}
