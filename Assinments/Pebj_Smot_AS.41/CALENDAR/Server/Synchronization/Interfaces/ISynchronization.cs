using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Synchronization.Interfaces
{
    interface ISynchronization
    {
        DateTime sync();
        IDataChange[] getChangesSince(DateTime time);
    }
}
