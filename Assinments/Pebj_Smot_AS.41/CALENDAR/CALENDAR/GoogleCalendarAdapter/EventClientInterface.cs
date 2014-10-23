using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.GoogleCalendarAdapter
{
    interface EventClientInterface
    {
        public EventManagement.EventComponent[] list();
    }
}
