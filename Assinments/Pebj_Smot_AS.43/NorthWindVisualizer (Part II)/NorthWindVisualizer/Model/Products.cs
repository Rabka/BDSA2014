//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWindVisualizer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Products : INotifyPropertyChanged
    {
        public Products()
        {
            this.Order_Details = new HashSet<Order_Details>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private int _ProductID { get; set; }
        private string _ProductName { get; set; }
        private Nullable<int> _SupplierID { get; set; }
        private Nullable<int> _CategoryID { get; set; }
        private string _QuantityPerUnit { get; set; }
        private Nullable<decimal> _UnitPrice { get; set; }
        private Nullable<short> _UnitsInStock { get; set; }
        private Nullable<short> _UnitsOnOrder { get; set; }
        private Nullable<short> _ReorderLevel { get; set; }
        private bool _Discontinued { get; set; }
        private Categories _Categories { get; set; }
        private ICollection<Order_Details> _Order_Details { get; set; }
        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
                NotifyPropertyChanged("ProductID");
            }
        }
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                NotifyPropertyChanged("ProductName");
            }
        }
        public Nullable<int> SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                _SupplierID = value;
                NotifyPropertyChanged("SupplierID");
            }
        }
        public Nullable<int> CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                _CategoryID = value;
                NotifyPropertyChanged("CategoryID");
            }
        }
        public string QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = value;
                NotifyPropertyChanged("QuantityPerUnit");
            }
        }
        public Nullable<decimal> UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
                NotifyPropertyChanged("UnitPrice");
            }
        }
        public Nullable<short> UnitsInStock
        {
            get
            {
                return _UnitsInStock;
            }
            set
            {
                _UnitsInStock = value;
                NotifyPropertyChanged("UnitsInStock");
            }
        }
        public Nullable<short> UnitsOnOrder
        {
            get
            {
                return _UnitsOnOrder;
            }
            set
            {
                _UnitsOnOrder = value;
                NotifyPropertyChanged("UnitsOnOrder");
            }
        }
        public Nullable<short> ReorderLevel
        {
            get
            {
                return _ReorderLevel;
            }
            set
            {
                _ReorderLevel = value;
                NotifyPropertyChanged("Fax");
            }
        }
        public bool Discontinued
        {
            get
            {
                return _Discontinued;
            }
            set
            {
                _Discontinued = value;
                NotifyPropertyChanged("Discontinued");
            }
        }
        public virtual Categories Categories
        {
            get
            {
                return _Categories;
            }
            set
            {
                _Categories = value;
                NotifyPropertyChanged("Categories");
            }
        }
        public virtual ICollection<Order_Details> Order_Details
        {
            get
            {
                return _Order_Details;
            }
            set
            {
                _Order_Details = value;
                NotifyPropertyChanged("Order_Details");
            }
        }
    }
}
