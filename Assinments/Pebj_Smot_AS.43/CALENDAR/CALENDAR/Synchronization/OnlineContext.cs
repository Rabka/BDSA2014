using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Synchronization
{
    public class OnlineContext
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

        public void AddAccount(DBObject newAccount)
        {
            throw new NotImplementedException();
        }
        public void RemoveAccount(DBObject account)
        {
            throw new NotImplementedException();
        }
        public void UpdateAccount(DBObject account)
        {
            throw new NotImplementedException();
        }
        public Account GetAccount(int itemIndex)
        {
            throw new NotImplementedException();
        }
        public Account GetAccount(string username)
        {
            throw new NotImplementedException();
        }
        public int GetAccountsCount()
        {
            throw new NotImplementedException();
        }
        public void AddEvent(DBObject newAccount)
        {
            throw new NotImplementedException();
        }
        public void RemoveEvent(DBObject account)
        {
            throw new NotImplementedException();
        }
        public void UpdateEvent(DBObject account)
        {
            throw new NotImplementedException();
        }
        public EventComponent GetEventComponent(int itemIndex)
        {
            throw new NotImplementedException();
        }
        public int GetEventsCount()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void SetLastSync(DateTime dt)
        {
            _lastSyncDateTime = dt;
        }
        public void checkOnlineStatus()
        {
            //SetOfflineOnlineInterface(true);
        }
        private void SetOfflineOnlineInterface(bool isOnline)
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
        public bool isOnline()
        {
            return (_syncStrategy is Online);
        }

        EventComponent[] GetEventComponents(DateTime from, DateTime to)
        {
            throw new NotImplementedException();

        }
    }
}
