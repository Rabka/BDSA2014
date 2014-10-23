using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Synchronization
{
    class Synchronization : Server.Synchronization.Interfaces.ISynchronization
    {
        public DateTime sync()
        {
            return DateTime.Now;
        }
        public Interfaces.IDataChange[] getChangesSince(DateTime dt)
        {
            return new DataChange[0];
        }
    }
}
