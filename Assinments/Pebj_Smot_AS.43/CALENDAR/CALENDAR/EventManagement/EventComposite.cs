using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;
using System.Windows.Forms;
namespace CALENDAR.EventManagement
{
    public class EventComposite : EventComponent
    {
        public EventComponent[] eventComponents;

        public EventComposite(string title, string description, Account ownedByAccount)
        {
            OwnedByAccount = ownedByAccount;
            Description = description;
            Title = title;
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
