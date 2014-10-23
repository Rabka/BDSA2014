using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Storage
{
    class Abstraction
    {
        private DBTypeImplementor _imp;
        public Abstraction(DBTypeImplementor imp)
        {
            this._imp = imp;
        }
    }
}
