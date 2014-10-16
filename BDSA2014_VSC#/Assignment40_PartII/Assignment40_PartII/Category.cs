using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment40_PartII
{
    /// <summary>
    /// A data class to contain information from categories.txt
    /// </summary>
    public class Category
    {
        public string CategoryName;
        public string Description;

        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
        }
    }
}
