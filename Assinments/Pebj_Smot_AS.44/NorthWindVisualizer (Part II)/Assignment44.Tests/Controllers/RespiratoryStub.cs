using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment44.Models;

namespace Assignment44.Tests.Controllers
{
    class RespiratoryStub : IRespiratory
    {

        public IQueryable<Products> Products()
        {
            var p = new List<Products>()
                     {
                         new Products(1, "p1", 2, 11, "1 spsk", (decimal?) 11.11, 111, 1111, 11111,
                             false, Categories().First())
                     };
            return from b in p.AsQueryable() select b;
        }

        public IQueryable<Categories> Categories()
        {
            var c = new List<Categories>()
                     {
                         new Categories(1,"c1","En ting",null)
                     };
            return from b in c.AsQueryable() select b;
        }

        public IQueryable<Orders> Orders()
        {
            var o = new List<Orders>()
                     {
                         new Orders(1,DateTime.Today,"Et skib","En addresse","En by","En region","En code","Et land")
                     };
            return from b in o.AsQueryable() select b;
        }

        public IQueryable<Order_Details> OrderDetails()
        {
            var od = new List<Order_Details>()
                     {
                         new Order_Details(1,1,(decimal) 11.11,10,10.1f,Orders().First(),Products().First())
                     };
            return from b in od.AsQueryable() select b;
        }
    }
}
