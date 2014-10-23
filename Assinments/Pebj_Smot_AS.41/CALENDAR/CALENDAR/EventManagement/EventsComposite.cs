using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;

namespace CALENDAR.EventManagement
{
    class EventsComposite : DBObject,EventComponent
    {
        public string TableID { get; set; } 

        private EventComponent[] _eventComponents;

        public EventsComposite(EventComponent[] eventComponents)
        {
            _eventComponents = eventComponents;
        }
    }
}
