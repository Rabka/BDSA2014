using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.GoogleCalendarAdapter
{
    class EventAdapter : EventClientInterface
    {
        private GoogleRestAPILegacyClass adaptee;
        private string syncToken = "";
        public EventManagement.EventComponent[] list()
        {
            //adaptee.list(syncToken);
            return null;
        }
    }
}
