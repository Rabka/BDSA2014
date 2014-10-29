using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
using CALENDAR.Synchronization;

namespace CALENDAR.EventManagement
{
    public class EventLeaf : EventComponent
    {
        public EventLeaf(string title, string description, DateTime dateFrom, DateTime dateTo, Account ownedByAccount, Account[] sharedWithAccounts, INotification[] notifications)
        {
            Title = title;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Description = description;
            OwnedByAccount = ownedByAccount;
            SharedWithAccounts = sharedWithAccounts;
            Notifications = notifications;
        }

        public int TableID { get; set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Account OwnedByAccount { get; private set; }
        public Account[] SharedWithAccounts { get; private set; }
        public INotification[] Notifications { get; private set; }
        public EventComponent[] GetLeafs()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public bool IsLeaf()
        {
            throw new NotImplementedException();
        }
    }
}
