using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.EventManagement
{
    public interface INotification
    {
        DateTime Date { get; }
        bool HasBeenProccesed { get; set; }
    }
}
