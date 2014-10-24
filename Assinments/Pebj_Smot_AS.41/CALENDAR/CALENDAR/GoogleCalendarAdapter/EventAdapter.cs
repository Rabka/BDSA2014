using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;
namespace CALENDAR.GoogleCalendarAdapter
{
    class EventAdapter : IEventClient
    {
        private GoogleRestAPILegacyClass adaptee;
        private string syncToken = "";
        public EventManagement.EventComponent[] List(Season season)
        {
            //adaptee.list(syncToken);
            throw new NotImplementedException();
        }
    }
}
