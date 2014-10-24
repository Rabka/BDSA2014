using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
using CALENDAR.Storage;

namespace CALENDAR.EventManagement
{
    class EventLeaf : EventComponent, IEvent
    {
        public EventLeaf(INotification[] notifications, Account[] sharedWithAccounts, Account ownedByAccount, string description, DateTime dateTo, DateTime dateFrom, string id)
        {
            Id = id;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Description = description;
            OwnedByAccount = ownedByAccount;
            SharedWithAccounts = sharedWithAccounts;
            Notifications = notifications;
        }
        public void Draw()
        {
            throw new NotImplementedException();
        }
        public void Add(EventLogic eventLogic)
        {
            throw new NotImplementedException();
        }
        public void Update(EventLogic eventLogic)
        {
            throw new NotImplementedException();
        }
        public void Delete(EventLogic eventLogic)
        {
            throw new NotImplementedException();
        }
        private string tableID;
        public string TableID { get { return tableID; } set { tableID = value; } } 
        public string Id { get; private set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public string Description { get; private set; }
        public Account OwnedByAccount { get; private set; }
        public Account[] SharedWithAccounts { get; private set; }
        public INotification[] Notifications { get; private set; }
    }
}
