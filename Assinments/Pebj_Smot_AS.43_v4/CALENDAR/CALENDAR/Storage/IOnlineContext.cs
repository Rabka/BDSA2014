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
        void AddAccount(IAccount newAccount);
        void RemoveAccount(IAccount account);
        void UpdateAccount(IAccount account);
        IAccount GetAccount(int itemIndex);
        IAccount GetAccount(string username);
        IAccount GetAccount(string email, bool inputIsEmail);
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
