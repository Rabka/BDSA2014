using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
namespace ComponentTesting.TestStubs
{
    public class SeasonStub : ISeason
    {
        List<IChangeCommand> changeCommands = new List<IChangeCommand>();
        public SeasonStub()
        {
            OnlineContext = new OnlineContextStub();
        }
        public void AddChangeCommand(IChangeCommand command)
        {
            if (command == null)
                throw new ArgumentException("Null is not acceptable argument");
            changeCommands.Add(command);
        }
        public void UndoLastChangeCommand()
        {
            changeCommands[changeCommands.Count - 1].Undo(OnlineContext);
        }
        public void UndoAllChangeCommands()
        {
            changeCommands.ForEach(x => x.Undo(OnlineContext));
        }
        public void SyncChangeCommands()
        {
            OnlineContext.Sync();
        }

        public Account CurrentAccount { get; set; }
        public IOnlineContext OnlineContext { get; private set; }
    }
}
