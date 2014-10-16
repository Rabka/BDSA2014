using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Assignment40_PartII
{

    public class Category
    {
        public string CategoryID;
        public string Description;
        public string CategoryName;
        public object Picture;

        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
        }
    }
}
