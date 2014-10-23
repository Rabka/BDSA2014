using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.GoogleCalendarAdapter
{
    interface IEventClient
    {
        EventManagement.EventComponent[] List();
    }
}
