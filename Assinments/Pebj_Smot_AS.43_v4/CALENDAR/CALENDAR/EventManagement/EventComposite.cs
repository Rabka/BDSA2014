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

        public EventComposite(string title, string description, Account ownedByAccount,IAccount[] sharedWithAccount)
        {
            SharedWithAccounts = sharedWithAccount;
            eventComponents = new EventComponent[0];
            OwnedByAccount = ownedByAccount;
            Description = description;
            Title = title;
        }

        public int TableID { get; set; }
        public DateTime DateFrom
        {
            get
            {
                return eventComponents.Select(x => x.DateFrom).Min();
            }
            set
            {

            }
        }
        public DateTime DateTo
        {
            get
            {
                return eventComponents.Select(x => x.DateTo).Max();
            }
            set
            {

            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public IAccount OwnedByAccount { get; private set; }
        public IAccount[] SharedWithAccounts { get; private set; }
        public INotification[] Notifications
        {
            get
            {
                List<INotification> notifications = new List<INotification>();
                foreach (EventComponent component in eventComponents)
                {
                    notifications.AddRange(component.Notifications);
                }
                return notifications.ToArray();
            }
            set
            {

            }
        }

        public EventComponent[] GetLeafs()
        {
            List<EventComponent> leafs = new List<EventComponent>();
            foreach (EventComponent component in eventComponents)
            {
               leafs.AddRange(component.GetLeafs());
            }
            return leafs.ToArray();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public bool IsLeaf()
        {
            return false;
        }
    }
}
