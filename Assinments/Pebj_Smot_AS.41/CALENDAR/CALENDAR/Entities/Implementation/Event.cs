using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Entities.Implementation
{
    public class Event : CALENDAR.Entities.Interfaces.IEvent
    {
        /// <summary>
        /// Event constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="description"></param>
        /// <param name="notifications"></param>
        public Event(string id, DateTime dateFrom, DateTime dateTo, string description, CALENDAR.Entities.Interfaces.INotification[] notifications,Account[] ownedByAccounts,Account[] sharedWithAccount)
        {
            this.id = id;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.description = description;
            this.notifications = notifications;
        }
        string id = "";
        DateTime dateFrom = DateTime.Now;
        DateTime dateTo = DateTime.Now;
        string description = "";
        CALENDAR.Entities.Interfaces.INotification[]  notifications;
        public Account[] ownedByAccounts;
        public Account[] sharedWithAccounts;
        /// <summary>
        /// Gets a list of accounts who has the right to edit the event.
        /// Accounts returned this way does not include email or password.
        /// </summary>
        /// <returns>Account</returns>
        public Account[] getOwnedByAccounts()
        {
            return ownedByAccounts;
        }
        /// <summary>
        /// Gets a list of accounts who has the right to observe the event (shared).
        /// Accounts returned this way does not include email or password.
        /// </summary>
        /// <returns>Account</returns>
        public Account[] getSharedWithAccounts()
        {
            return sharedWithAccounts;
        }
        /// <summary>
        /// gets the id of the event
        /// </summary>
        /// <returns>string</returns>
        public string getID()
        {
            return id;
        }
        /// <summary>
        /// gets the dateFrom of the event
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime getDateFrom()
        {
            return dateFrom;
        }
        /// <summary>
        /// gets the dateFrom of the event
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime getDateTo()
        {
            return dateTo;
        }
        /// <summary>
        /// gets the description of the event
        /// </summary>
        /// <returns>string</returns>
        public string getDescription()
        {
            return description;
        }
        /// <summary>
        /// gets the notifications attached to the event
        /// </summary>
        /// <returns>CALENDAR.Entities.Interfaces.INotification[]</returns>
        public CALENDAR.Entities.Interfaces.INotification[] getNotifications()
        {
            return notifications;
        }
    }
}
