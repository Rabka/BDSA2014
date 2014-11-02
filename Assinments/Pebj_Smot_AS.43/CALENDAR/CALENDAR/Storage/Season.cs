using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.EventManagement;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
using CALENDAR.GoogleCalendarAdapter;
using CALENDAR.Commands;
namespace CALENDAR.Storage
{
    public class Season : ISeason
    {
        private List<IChangeCommand> changeCommands;
        public Account CurrentAccount { get; set; }
        public IOnlineContext OnlineContext { get; private set; }
        public Season()
        {
            OnlineContext = new OnlineContext();
            changeCommands = new List<IChangeCommand>();
        }
        public void AddChangeCommand(IChangeCommand command)
        {
            throw new NotImplementedException();
        }
        public void UndoLastChangeCommand()
        {
            throw new NotImplementedException();
        }
        public void UndoAllChangeCommands()
        {
            throw new NotImplementedException();
        }
        public void SyncChangeCommands()
        {
            throw new NotImplementedException();
        }

    }
}
