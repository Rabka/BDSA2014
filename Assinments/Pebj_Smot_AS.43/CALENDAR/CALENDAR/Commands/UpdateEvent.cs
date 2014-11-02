using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.EventManagement;
using CALENDAR.Storage;

namespace CALENDAR.Commands
{
    class UpdateEvent : IChangeCommand
    {
        public EventLeaf eventLeafSnapshot;
        public void Execute(IOnlineContext context)
        {
            throw new NotImplementedException();
        }
        public void Undo(IOnlineContext context)
        {
            throw new NotImplementedException();
        }
    }
}
