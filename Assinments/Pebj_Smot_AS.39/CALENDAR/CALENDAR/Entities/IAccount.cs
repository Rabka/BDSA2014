using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Entities
{
    interface IAccount
    {
        string Id { get; }
        string Name { get; }
        string Username { get; }
        string Password { get; }
        string Email { get; }
    }
}
