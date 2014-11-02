using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using NorthWindVisualizer.Model;
using System.Collections.ObjectModel;
namespace NorthWindVisualizer.ModelView
{
    public delegate void ModelChangeEvent();
    public class OrdersModelView : INotifyPropertyChanged
    {
        private Orders _Order;
        private INorthWind northWind;
        public ModelChangeEvent modelChangeEvent;
        public OrdersModelView(INorthWind northWind)
        {
            this.northWind = northWind;
            modelChangeEvent += modelChanged;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public Orders CurrentOrder
        {
            get { return _Order; }
            set
            {
                _Order = value;
                NotifyPropertyChanged("CurrentOrder");
                NotifyPropertyChanged("TotalPrice");
            }
        }
        private void modelChanged()
        {
            //Force update of view.
            CurrentOrder = CurrentOrder;
            NotifyPropertyChanged("ListOrders");
            NotifyPropertyChanged("TotalPrice");
        }
        public double TotalPrice
        {
            get
            {
                if (CurrentOrder != null)
                    return CurrentOrder.Order_Details.Sum(x => getOrderDetailTotal(x));
                return 0;
            }
        }
        private double getOrderDetailTotal(Order_Details orderDetails)
        {
            return Convert.ToDouble(orderDetails.Quantity * orderDetails.UnitPrice) - Convert.ToDouble(orderDetails.Discount);
        }
        public ObservableCollection<Orders> ListOrders
        {
            get
            {
                var orders = new ObservableCollection<Orders>();
                foreach (Orders order in northWind.Orders())
                {
                    orders.Add(order);
                }
                return orders;
            }
        }


    }
}
