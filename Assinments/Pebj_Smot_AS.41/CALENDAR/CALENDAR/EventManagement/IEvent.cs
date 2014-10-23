using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;

namespace CALENDAR.EventManagement
{
    interface IEvent
    {
        string Id { get; }
        DateTime DateFrom { get; }
        DateTime DateTo { get; }
        string Description { get; }
        Account[] OwnedByAccounts { get; }
        Account[] SharedWithAccounts { get; }
        INotification[] Notifications { get; }

    }
}
