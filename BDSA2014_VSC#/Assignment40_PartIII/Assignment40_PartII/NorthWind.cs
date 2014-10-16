using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assignment40_PartII

{

    public delegate void newOrderEventDelegate(Order addedOrder);
    class NorthWind
    {
        Respiratory respiratory;
        public newOrderEventDelegate newOrderEvent;
        public NorthWind(Respiratory respiratory)
        {
            this.respiratory = respiratory;
        }
        public void AddOrder(DateTime requiredDate, string name, string address, string city, string region, string postalCode, string country)
        {
            Order order = new Order(0,null,null,DateTime.Now,requiredDate,null,-1,-1,name,address,city,region,postalCode,country);
            order.RequiredDate = requiredDate;
            order.ShipName = name;
            order.ShipAddress = address;
            order.ShipCity = city;
            order.ShipRegion = region;
            order.ShipPostalCode = postalCode;
            order.ShipCountry = country;
            order.OrderDate = DateTime.Now;
            respiratory.CreateOrder(order);
                newOrderEvent(order);
        }
        public Product[] Products()
        {
            return respiratory.Products();
        }
        public Order[] Orders()
        {
            return respiratory.Orders();
        }
    }
}
