using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Storage.implementation
{
    class Abstraction
    {
        DBTypeImplementor imp;
        public Abstraction(DBTypeImplementor imp)
        {
            this.imp = imp;
        }
    }
}
