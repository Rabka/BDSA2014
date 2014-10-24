using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;

namespace CALENDAR.EventManagement
{
    interface EventComponent : DBObject
    {
        void Add(EventLogic eventLogic);
        void Update(EventLogic eventLogic);
        void Delete(EventLogic eventLogic);
        void Draw();
    }
}
