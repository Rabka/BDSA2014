using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Entities.Implementation
{
    public class Notification
    {
        /// <summary>
        /// Notification constructor
        /// </summary>
        /// <param name="dateForNotification"></param>
        /// <param name="processed"></param>
        public Notification(DateTime dateForNotification, bool processed)
        {
            this.dateForNotification = dateForNotification;
            this.processed = processed;
        }
        DateTime dateForNotification = DateTime.Now;
        bool processed = false;
        /// <summary>
        /// gets the upcomming date.
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime getDate()
        {
            return dateForNotification;
        }
        /// <summary>
        /// has the notification message been sent?
        /// </summary>
        /// <returns>boolean</returns>
        public bool hasBeenProccesed()
        {
            return processed;
        }
    }
}
