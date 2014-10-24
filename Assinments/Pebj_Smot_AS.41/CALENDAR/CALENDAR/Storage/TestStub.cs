using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Storage
{
    class TestStub : DBTypeImplementor
    {
        public TestStub(string something)
        {

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
        public Account[] GetAccounts(int from, int to)
        {
            throw new NotImplementedException();
        }
        public Account GetAccount(string username, string password)
        {
            throw new NotImplementedException();
        }
        public Account GetAccount(string tableID)
        {
            throw new NotImplementedException();
        }
        public int GetAccountsCount()
        {
            throw new NotImplementedException();
        }
        public void AddEvent(EventLeaf newEvent)
        {
            throw new NotImplementedException();
        }
        public void RemoveEvent(EventLeaf @event)
        {
            throw new NotImplementedException();
        }
        public void UpdateEvent(EventLeaf @event)
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
