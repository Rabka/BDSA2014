using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;

namespace CALENDAR.EventManagement
{
    public interface INotification : DBObject
    {
        DateTime Date { get; }
        bool HasBeenProccesed { get; set; }
    }
}
