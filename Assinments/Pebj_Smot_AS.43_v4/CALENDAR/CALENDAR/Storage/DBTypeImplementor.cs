﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
namespace CALENDAR.Storage
{
    interface DBTypeImplementor
    {
         void AddAccount(IAccount newAccount);
         void RemoveAccount(IAccount account);
         void UpdateAccount(IAccount account);
         IAccount[] GetAccounts(int from,int to);
         IAccount GetAccountByUsername(string username);
         IAccount GetAccountByTableID(string tableID);
         int GetAccountsCount();
         void AddEvent(EventComponent newEvent);
         void RemoveEvent(EventComponent @event);
         void UpdateEvent(EventComponent @event);
         EventComponent GetEvent(string tableID);
         EventComponent[] GetEvents(DateTime from, DateTime to);
        
    }
}