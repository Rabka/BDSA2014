using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;
namespace CALENDAR.GoogleCalendarAdapter
{
    interface IEventClient
    {
        EventManagement.EventComponent[] List(Season season);
    }
}
