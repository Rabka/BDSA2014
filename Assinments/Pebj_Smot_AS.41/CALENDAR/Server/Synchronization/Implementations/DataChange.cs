using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Synchronization
{
    public class DataChange : Server.Synchronization.Interfaces.IDataChange
    {
        public Server.Synchronization.Interfaces.changeType getType()
        {
            return Interfaces.changeType.Event;
        }
        public string getObjectID()
        {
            return null;
        }
        public object getObject()
        {
            return null;
        }
    }
}