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

    public partial class Employees : INotifyPropertyChanged
    {
        public Employees()
        {
            this.Employees1 = new HashSet<Employees>();
            this.Orders = new HashSet<Orders>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private int _EmployeeID { get; set; }
        private string _LastName { get; set; }
        private string _FirstName { get; set; }
        private string _Title { get; set; }
        private string _TitleOfCourtesy { get; set; }
        private Nullable<System.DateTime> _BirthDate { get; set; }
        private Nullable<System.DateTime> _HireDate { get; set; }
        private string _Address { get; set; }
        private string _City { get; set; }
        private string _Region { get; set; }
        private string _PostalCode { get; set; }
        private string _Country { get; set; }
        private string _HomePhone { get; set; }
        private string _Extension { get; set; }
        private byte[] _Photo { get; set; }
        private string _Notes { get; set; }
        private Nullable<int> _ReportsTo { get; set; }
        private string _PhotoPath { get; set; }
        private ICollection<Employees> _Employees1 { get; set; }
        private Employees _Employees2 { get; set; }
        private ICollection<Orders> _Orders { get; set; }
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
                NotifyPropertyChanged("EmployeeID");
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                NotifyPropertyChanged("LastName");
            }
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public string TitleOfCourtesy
        {
            get
            {
                return _TitleOfCourtesy;
            }
            set
            {
                _TitleOfCourtesy = value;
                NotifyPropertyChanged("TitleOfCourtesy");
            }
        }
        public Nullable<System.DateTime> BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
                NotifyPropertyChanged("BirthDate");
            }
        }
        public Nullable<System.DateTime> HireDate
        {
            get
            {
                return _HireDate;
            }
            set
            {
                _HireDate = value;
                NotifyPropertyChanged("HireDate");
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
                NotifyPropertyChanged("Address");
            }
        }
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
                NotifyPropertyChanged("City");
            }
        }
        public string Region
        {
            get
            {
                return _Region;
            }
            set
            {
                _Region = value;
                NotifyPropertyChanged("Region");
            }
        }
        public string PostalCode
        {
            get
            {
                return _PostalCode;
            }
            set
            {
                _PostalCode = value;
                NotifyPropertyChanged("PostalCode");
            }
        }
        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
                NotifyPropertyChanged("Country");
            }
        }
        public string HomePhone
        {
            get
            {
                return _HomePhone;
            }
            set
            {
                _HomePhone = value;
                NotifyPropertyChanged("HomePhone");
            }
        }
        public string Extension
        {
            get
            {
                return _Extension;
            }
            set
            {
                _Extension = value;
                NotifyPropertyChanged("Extension");
            }
        }
        public byte[] Photo
        {
            get
            {
                return _Photo;
            }
            set
            {
                _Photo = value;
                NotifyPropertyChanged("EmployeeID");
            }
        }
        public string Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                _Notes = value;
                NotifyPropertyChanged("Notes");
            }
        }
        public Nullable<int> ReportsTo
        {
            get
            {
                return _ReportsTo;
            }
            set
            {
                _ReportsTo = value;
                NotifyPropertyChanged("ReportsTo");
            }
        }
        public string PhotoPath
        {
            get
            {
                return _PhotoPath;
            }
            set
            {
                _PhotoPath = value;
                NotifyPropertyChanged("PhotoPath");
            }
        }
        public virtual ICollection<Employees> Employees1
        {
            get
            {
                return _Employees1;
            }
            set
            {
                _Employees1 = value;
                NotifyPropertyChanged("Employees1");
            }
        }
        public virtual Employees Employees2
        {
            get
            {
                return _Employees2;
            }
            set
            {
                _Employees2 = value;
                NotifyPropertyChanged("Employees2");
            }
        }
        public virtual ICollection<Orders> Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;
                NotifyPropertyChanged("Orders");
            }
        }
    }
}