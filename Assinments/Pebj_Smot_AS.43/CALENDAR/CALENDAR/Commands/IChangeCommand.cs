using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;
namespace CALENDAR.Commands
{
    public interface IChangeCommand
    {
        void SetSeason(ISeason season);
        void Execute();
        void Undo();
    }
}
