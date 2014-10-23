using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Entities.Interfaces
{
    interface IEvent
    {
        string getID();
        DateTime getDateFrom();
        DateTime getDateTo();
        string getDescription();
        Entities.Implementation.Account[] getOwnedByAccounts();
        Entities.Implementation.Account[] getSharedWithAccounts();
        CALENDAR.Entities.Interfaces.INotification[] getNotifications();

    }
}
