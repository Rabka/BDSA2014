using System;
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
         void AddAccount(DBObject newAccount);
         void RemoveAccount(DBObject account);
         void UpdateAccount(DBObject account);
         Account GetAccount(int itemIndex);
         int GetAccountsCount();
         void AddEvent(DBObject newAccount);
         void RemoveEvent(DBObject account);
         void UpdateEvent(DBObject account);
         EventLeaf GetEvent(int itemIndex);
         int GetEventsCount();
        
    }
}
