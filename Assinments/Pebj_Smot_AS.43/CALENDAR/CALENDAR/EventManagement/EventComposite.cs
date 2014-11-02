using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
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
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IAccount OwnedByAccount { get; private set; }
        public IAccount[] SharedWithAccounts { get; private set; }
        public INotification[] Notifications { get; set; }

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
