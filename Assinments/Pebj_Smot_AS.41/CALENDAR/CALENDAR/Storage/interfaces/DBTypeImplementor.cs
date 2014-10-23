using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Storage.implementation
{
    interface DBTypeImplementor
    {
        public void Add(DBRow row);
        public void Remove(DBRow row);
        public void Update(DBRow row);
        public void Get(int itemIndex);
        public int ItemCount();
    }
}
