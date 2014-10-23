using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Commands
{
    interface ChangeCommand
    {
        public void execute();
        public void undo();
    }
}
