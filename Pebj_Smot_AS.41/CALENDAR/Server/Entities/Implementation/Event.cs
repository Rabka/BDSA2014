using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Entities.Implementation
{
    public class Event : Server.Entities.Interfaces.IEvent
    {
        /// <summary>
        /// Event constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="description"></param>
        /// <param name="notifications"></param>
        public Event(string id, DateTime dateFrom, DateTime dateTo, string description, Server.Entities.Interfaces.INotification[] notifications)
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
        Server.Entities.Interfaces.INotification[] notifications;

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
        /// <returns>Server.Entities.Interfaces.INotification[]</returns>
        public Server.Entities.Interfaces.INotification[] getNotifications()
        {
            return notifications;
        }
    }
}
