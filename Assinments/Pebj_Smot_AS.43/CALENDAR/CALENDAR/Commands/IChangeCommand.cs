using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Commands
{
    public interface IChangeCommand
    {
        void Execute();
        void Undo();
    }
}
