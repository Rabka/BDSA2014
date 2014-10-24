using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
using CALENDAR.Storage;
namespace CALENDAR.Synchronization
{
    interface ISyncStrategy 
    {
        void Sync();
        void AddAccount(DBObject newAccount);
        void RemoveAccount(DBObject account);
        void UpdateAccount(DBObject account);
        Account GetAccount(int itemIndex);
        Account GetAccount(string username);
        int GetAccountsCount();
        void AddEvent(DBObject newAccount);
        void RemoveEvent(DBObject account);
        void UpdateEvent(DBObject account);
        EventComponent GetEvent(int itemIndex);
        EventComponent[] GetEvents(DateTime from, DateTime to);
        int GetEventsCount();
    }
}
