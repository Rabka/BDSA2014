using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.GoogleCalendarAdapter
{
    class EventAdapter : IEventClient
    {
        private GoogleRestAPILegacyClass adaptee;
        private string syncToken = "";
        public EventManagement.EventComponent[] List()
        {
            //adaptee.list(syncToken);
            return null;
        }
    }
}
