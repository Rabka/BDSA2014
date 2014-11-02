using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NorthWindVisualizer.Model;
using System.Collections.ObjectModel;
namespace NorthWindVisualizer
{
    class OrdersViewModel
    {
        public ObservableCollection<Orders> ListOrders
        {
            get
            {
                Orders order = new Orders();
                order.OrderID = 2;
                order.OrderDate = DateTime.Now;
                return new ObservableCollection<Orders>() { order };
                //   return northWind.Orders();
            }

        }
    }
}
