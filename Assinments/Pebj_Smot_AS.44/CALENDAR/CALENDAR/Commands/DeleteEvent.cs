using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.EventManagement;
using CALENDAR.Storage;
namespace CALENDAR.Commands
{
    class DeleteEvent : IChangeCommand
    {
        public EventLeaf eventLeafSnapshot;
        public void SetOnlineContext(IOnlineContext onlineContext)
        {
            throw new NotImplementedException();
        }
        public void Execute()
        {
            throw new NotImplementedException();
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
