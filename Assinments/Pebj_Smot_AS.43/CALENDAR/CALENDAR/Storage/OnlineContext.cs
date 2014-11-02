using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Storage
{
    public class OnlineContext : IOnlineContext
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

        public void AddAccount(Account newAccount)
        {
            throw new NotImplementedException();
        }
        public void RemoveAccount(Account account)
        {
            throw new NotImplementedException();
        }
        public void UpdateAccount(Account account)
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
        public void AddEvent(EventComponent newEvent)
        {
            throw new NotImplementedException();
        }
        public void RemoveEvent(EventComponent @event)
        {
            throw new NotImplementedException();
        }
        public void UpdateEvent(EventComponent @event)
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

        public void SetOfflineOnlineInterface(bool isOnline)
        {
            throw new NotImplementedException();
        }

        public bool isOnline()
        {
            return (_syncStrategy is Online);
        }

        public EventComponent[] GetEventComponents(DateTime @from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
