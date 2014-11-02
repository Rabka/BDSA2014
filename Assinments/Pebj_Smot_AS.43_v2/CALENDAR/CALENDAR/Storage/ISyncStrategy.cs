﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Storage
{
    interface ISyncStrategy
    {
        void Sync();
        void SetDBType(DBTypeImplementor impl);
        void AddAccount(Account newAccount);
        void RemoveAccount(Account account);
        void UpdateAccount(Account account);
        Account[] GetAccounts(int from, int to);
        Account GetAccountByUsername(string username);
        Account GetAccountByTableID(string tableID);
        int GetAccountsCount();
        void AddEvent(EventComponent newEvent);
        void RemoveEvent(EventComponent @event);
        void UpdateEvent(EventComponent @event);
        EventComponent GetEvent(string tableID);
        EventComponent[] GetEvents(DateTime from, DateTime to);
    }
}