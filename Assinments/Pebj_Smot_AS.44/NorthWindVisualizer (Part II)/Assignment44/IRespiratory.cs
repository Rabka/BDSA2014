using System.Linq;
using Assignment44.Models;

namespace Assignment44
{
    public interface IRespiratory
    {
        IQueryable<Products> Products();
        IQueryable<Categories> Categories();
        IQueryable<Orders> Orders();
        IQueryable<Order_Details> OrderDetails();
    }
}