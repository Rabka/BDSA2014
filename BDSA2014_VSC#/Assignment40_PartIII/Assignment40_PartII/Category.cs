using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assignment40_PartII
{

    public class Category
    {
        public string CategoryID;
        public virtual string Description;
        public string CategoryName;
        public virtual object Picture;

        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
        }
    }
}
