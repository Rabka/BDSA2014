using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;

namespace CALENDAR.Synchronization
{
    class Offline : ISyncStrategy
    {
        public void Sync()
        {
            throw new NotImplementedException();
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
        public EventComponent GetEvent(int itemIndex)
        {
            throw new NotImplementedException();
        }
        public int GetEventsCount()
        {
            throw new NotImplementedException();
        }
        public EventComponent[] GetEvents(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
