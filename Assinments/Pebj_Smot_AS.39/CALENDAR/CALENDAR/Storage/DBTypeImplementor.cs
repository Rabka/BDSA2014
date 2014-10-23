using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CALENDAR.Storage
{
    interface DBTypeImplementor
    {
        void Add(DBRow row);
        void Remove(DBRow row);
        void Update(DBRow row);
        void Get(int itemIndex);
        int ItemCount();
        
    }
}
