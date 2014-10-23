using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;

namespace CALENDAR.EventManagement
{
    class EventsComposite : DBObject,EventComponent
    {
        private string tableID;
        public string TableID { get { return tableID; } set { tableID = value; } } 

        private EventComponent[] _eventComponents;

        public EventsComposite(EventComponent[] eventComponents)
        {
            _eventComponents = eventComponents;
        }
    }
}
