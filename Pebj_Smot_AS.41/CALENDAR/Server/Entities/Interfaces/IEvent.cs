using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Entities.Interfaces
{
    interface IEvent
    {
        string getID();
        DateTime getDateFrom();
        DateTime getDateTo();
        string getDescription();
        Server.Entities.Interfaces.INotification[] getNotifications();

    }
}
