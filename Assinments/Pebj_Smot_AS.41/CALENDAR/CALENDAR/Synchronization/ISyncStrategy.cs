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
        void AddAccount(Account newAccount);
        void RemoveAccount(Account account);
        void UpdateAccount(Account account);
        Account[] GetAccounts(int from, int to);
        Account GetAccountByUsername(string username);
        Account GetAccountByTableID(string tableID);
        int GetAccountsCount();
        void AddEvent(EventLeaf newEvent);
        void RemoveEvent(EventLeaf @event);
        void UpdateEvent(EventLeaf @event);
        EventComponent GetEvent(string tableID);
        EventComponent[] GetEvents(DateTime from, DateTime to);
    }
}
