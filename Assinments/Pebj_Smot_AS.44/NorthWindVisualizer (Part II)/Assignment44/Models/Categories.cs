//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment44.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.Products = new HashSet<Products>();
        }
        public Categories(int newID, string categoryName, string description,byte[] picture)
        {
            this.CategoryID = newID;
            this.CategoryName = categoryName;
            this.Description = description;
            this.Picture = picture;
            this.Products = new HashSet<Products>();
        }
    
        public int CategoryID { get; private set; }
        public string CategoryName { get; private set; }
        public string Description { get; private set; }
        public byte[] Picture { get; private set; }    
        public virtual ICollection<Products> Products { get; private set; }
    }
}
