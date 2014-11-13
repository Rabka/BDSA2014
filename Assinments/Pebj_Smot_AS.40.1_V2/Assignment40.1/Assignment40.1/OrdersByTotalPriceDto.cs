using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartIII
{
    class OrdersByTotalPriceDto
    {
        public int OrderId ;
        public DateTime OrderDate;
        public string CustomerContactName;
        public decimal TotalPriceWithDiscount;
        public decimal TotalPrice;
        public Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            return null;
        }
    }
}
