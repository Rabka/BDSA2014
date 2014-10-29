using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Synchronization;
namespace CALENDAR.GoogleCalendarAdapter
{
    interface IEventClient
    {
        EventManagement.EventComponent[] List(Season season);
    }
}
