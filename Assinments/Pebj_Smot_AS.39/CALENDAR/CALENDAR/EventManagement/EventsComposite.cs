﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.EventManagement
{
    class EventsComposite : EventComponent
    {
        private EventComponent[] _eventComponents;

        public EventsComposite(EventComponent[] eventComponents)
        {
            _eventComponents = eventComponents;
        }
    }
}
