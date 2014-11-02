using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
using CALENDAR.Storage;

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
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Account OwnedByAccount { get; private set; }
        public Account[] SharedWithAccounts { get; private set; }
        public INotification[] Notifications { get; set; }

        public EventComponent[] GetLeafs()
        {
            return new EventComponent[] {this};
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
