﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
namespace CALENDAR.Commands
{
    class UpdateAccount : IChangeCommand
    {
        public Account accountSnapshot;
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
