﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.EventManagement;
namespace CALENDAR.Commands
{
    class DeleteEvent : IChangeCommand
    {
        public EventLeaf eventLeafSnapshot;
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
