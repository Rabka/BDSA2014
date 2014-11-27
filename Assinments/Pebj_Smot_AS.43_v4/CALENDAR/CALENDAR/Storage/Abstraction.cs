using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Storage
{
    class Abstraction : DBTypeImplementor
    {
        private DBTypeImplementor _imp;
        public Abstraction(DBTypeImplementor imp)
        {
            this._imp = imp;
        }
        public void AddAccount(IAccount newAccount)
        {
            throw new NotImplementedException();
        }
        public void RemoveAccount(IAccount account)
        {
            throw new NotImplementedException();
        }
        public void UpdateAccount(IAccount account)
        {
            throw new NotImplementedException();
        }
        public IAccount[] GetAccounts(int from, int to)
        {
            throw new NotImplementedException();
        }
        public IAccount GetAccountByUsername(string username)
        {
            throw new NotImplementedException();
        }
        public IAccount GetAccountByTableID(string tableID)
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
        public EventComponent GetEvent(string tableID)
        {
            throw new NotImplementedException();
        }
        public EventComponent[] GetEvents(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
