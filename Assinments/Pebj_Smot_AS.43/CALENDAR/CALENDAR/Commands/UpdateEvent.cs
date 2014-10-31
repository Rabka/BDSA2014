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
        public void SetSeason(ISeason season)
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
