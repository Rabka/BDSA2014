using System.Linq;
using NorthWindVisualizer.Model;

namespace NorthWindVisualizer
{
    public interface IRespiratory
    {
        IQueryable<Products> Products();
        IQueryable<Categories> Categories();
        IQueryable<Orders> Orders();
        void CreateOrder(Orders order);
    }
}