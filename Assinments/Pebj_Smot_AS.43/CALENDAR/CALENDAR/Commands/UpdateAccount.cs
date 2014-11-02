using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
namespace CALENDAR.Commands
{
    class UpdateAccount : IChangeCommand
    {
        public Account accountSnapshot;
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
