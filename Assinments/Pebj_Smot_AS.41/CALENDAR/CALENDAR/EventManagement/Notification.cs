using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.EventManagement
{
    public class Notification : INotification
    {
        /// <summary>
        /// Notification constructor
        /// </summary>
        /// <param name="dateForNotification"></param>
        /// <param name="processed"></param>
        public Notification(DateTime dateForNotification, bool processed)
        {
            Date = dateForNotification;
            HasBeenProccesed = processed;
        }

        public DateTime Date { get; private set; }
        public bool HasBeenProccesed { get; set; }
    }
}
