using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Entities.Interfaces
{
    public interface INotification
    {
        DateTime getDate();
        bool hasBeenProccesed();
        void markAsProcessed();
    }
}
