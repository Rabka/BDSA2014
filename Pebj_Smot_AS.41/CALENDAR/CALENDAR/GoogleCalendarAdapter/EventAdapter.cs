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
        private Storage.Storage storage;
        public EventAdapter(Storage.Storage storage)
        {
            this.storage = storage;
        }
        public EventManagement.EventComponent[] List()
        {
            //adaptee.list(syncToken);
            return null;
        }
    }
}
