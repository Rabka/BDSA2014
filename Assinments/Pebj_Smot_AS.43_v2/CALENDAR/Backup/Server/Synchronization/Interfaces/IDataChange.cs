using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Synchronization.Interfaces
{
    public enum changeType { Account, Event };
    interface IDataChange
    {
        changeType getType();
        string getObjectID();
        object getObject();
    }
}
