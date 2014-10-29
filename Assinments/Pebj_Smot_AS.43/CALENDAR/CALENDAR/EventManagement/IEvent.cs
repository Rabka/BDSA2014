using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;

namespace CALENDAR.EventManagement
{
    interface IEvent
    {
        DateTime DateFrom { get; }
        DateTime DateTo { get; }
        string Description { get; }
        Account OwnedByAccount { get; }
        Account[] SharedWithAccounts { get; }
        INotification[] Notifications { get; }

    }
}
