using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Storage
{
    public interface IOnlineContext
    {   
        DateTime Sync();
        void AddAccount(Account newAccount);
        void RemoveAccount(Account account);
        void UpdateAccount(Account account);
        Account GetAccount(int itemIndex);
        Account GetAccount(string username);
        int GetAccountsCount();
        void AddEvent(EventComponent newEvent);
        void RemoveEvent(EventComponent @event);
        void UpdateEvent(EventComponent @event);
        EventComponent GetEventComponent(int itemIndex);
        int GetEventsCount();
        void SetLastSync(DateTime dt);
        void checkOnlineStatus();
        void SetOfflineOnlineInterface(bool isOnline);
        bool isOnline();
        EventComponent[] GetEventComponents(DateTime from, DateTime to);
    }
}
