using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Synchronization
{
    interface ISynchronization
    {
        void SetLastSync(DateTime dt);
        DateTime Sync();
    }
}
