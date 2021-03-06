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
    
    public partial class Employees
    {
        public Employees()
        {
            this.Employees1 = new HashSet<Employees>();
            this.Orders = new HashSet<Orders>();
        }
    
        public int EmployeeID { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Title { get; private set; }
        public string TitleOfCourtesy { get; private set; }
        public Nullable<System.DateTime> BirthDate { get; private set; }
        public Nullable<System.DateTime> HireDate { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public string HomePhone { get; private set; }
        public string Extension { get; private set; }
        public byte[] Photo { get; private set; }
        public string Notes { get; private set; }
        public Nullable<int> ReportsTo { get; private set; }
        public string PhotoPath { get; private set; }
    
        public virtual ICollection<Employees> Employees1 { get; private set; }
        public virtual Employees Employees2 { get; private set; }
        public virtual ICollection<Orders> Orders { get; private set; }
    }
}
