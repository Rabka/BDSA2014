﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.EventManagement;

namespace CALENDAR.Commands
{
    class UpdateEvent : IChangeCommand
    {
        public EventLeaf eventLeafSnapshot;
        public void Execute()
        {
        }
        public void Undo()
        {
        }
    }
}