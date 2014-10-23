using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;

namespace CALENDAR.Storage
{
    class RDBMS : DBTypeImplementor
    {
        public RDBMS(string connectionString)
        {

        }
        public void AddAccount(DBObject newAccount)
        {
        }
        public void RemoveAccount(DBObject account)
        {
        }
        public void UpdateAccount(DBObject account)
        {
        }
        public Account GetAccount(int itemIndex)
        {
            return null;
        }
        public int GetAccountsCount()
        {
            return 0;
        }
        public void AddEvent(DBObject newAccount)
        {
        }
        public void RemoveEvent(DBObject account)
        {
        }
        public void UpdateEvent(DBObject account)
        {
        }
        public EventLeaf GetEvent(int itemIndex)
        {
            return null;
        }
        public int GetEventsCount()
        {
            return 0;
        }
    }
}

