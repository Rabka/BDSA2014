using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Synchronization
{
    class OnlineContext
    {   
        ISyncStrategy _syncStrategy;
        DateTime _lastSyncDateTime = DateTime.Now;
        /// <summary>
        /// Synchronizes the local database with that of the server.
        /// </summary>
        /// <returns>DateTime of last synchronization with the server. The database holds a "lastChanged" Date for all rows
        /// allowing the synchronization to get differences between the databases by simply using this date and take all rows with a lastChanged Date after
        /// the DateTime of last synchronization.
        /// </returns>
        public DateTime Sync()
        {
            _syncStrategy.Sync();
            //Do some synchronization.
            return DateTime.Now;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void SetLastSync(DateTime dt)
        {
            _lastSyncDateTime = dt;
        }

        public void SetOfflineOnlineInterface(bool isOnline)
        {
            if (isOnline && !(_syncStrategy is Online))
            {
                _syncStrategy = new Online();
            }
            else if (!isOnline && !(_syncStrategy is Offline))
            {
                _syncStrategy = new Offline();
            }
        }
    }
}
