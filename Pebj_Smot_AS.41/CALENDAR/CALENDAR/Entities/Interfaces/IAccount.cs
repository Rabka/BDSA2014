using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Entities.Interfaces
{
    interface IAccount
    {
        string getID();
        string getName();
        string getUsername();
        string getPassword();
        string getEmail();
    }
}
