using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Synchronization.Interfaces
{
    interface ISynchronization
    {
        void setLastSync(DateTime dt);
        DateTime sync();
    }
}
