using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Synchronization;

namespace CALENDAR.AccountManagement
{
    interface IAccount : DBObject
    {
        string Name { get; }
        string Username { get; }
        string Email { get; }
    }
}
