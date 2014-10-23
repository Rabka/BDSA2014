using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Synchronization
{
    class OnlineContext : CALENDAR.Synchronization.Interfaces.ISynchronization
    {
        SyncStrategy syncStrategy;
        DateTime lastSyncDateTime = DateTime.Now;
        /// <summary>
        /// Synchronizes the local database with that of the server.
        /// </summary>
        /// <returns>DateTime of last synchronization with the server. The database holds a "lastChanged" Date for all rows
        /// allowing the synchronization to get differences between the databases by simply using this date and take all rows with a lastChanged Date after
        /// the DateTime of last synchronization.
        /// </returns>
        public DateTime sync()
        {
            syncStrategy.sync();
            //Do some synchronization.
            return DateTime.Now;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void setLastSync(DateTime dt)
        {
            lastSyncDateTime = dt;
        }
        public void setOfflineOnlineInterface(bool isOnline)
        {
            if (isOnline && !(syncStrategy is Online))
            {
                syncStrategy = new Online();
            }
            else if (!isOnline && !(syncStrategy is Offline))
            {
                syncStrategy = new Offline();
            }
        }
    }
}
