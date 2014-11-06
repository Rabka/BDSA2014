using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;

namespace CALENDAR.Commands
{
    class DeleteAccount : IChangeCommand
    {
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
