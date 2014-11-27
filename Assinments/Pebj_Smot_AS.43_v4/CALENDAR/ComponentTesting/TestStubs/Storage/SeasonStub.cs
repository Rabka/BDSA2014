using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
namespace ComponentTesting.TestStubs.Storage
{
    public class SeasonStub : ISeason
    {
        List<IChangeCommand> changeCommands = new List<IChangeCommand>();
        public SeasonStub()
        {
            OnlineContext = new OnlineContextStub();
            //Initialized test content
            OnlineContext.AddAccount(new Account("SeaasonStub person", "u", "p", true));
        }
        public void AddChangeCommand(IChangeCommand command)
        {
            if (changeCommands.Contains(command))
                throw new Exception("ChangeCommand allready exists!");
            changeCommands.Add(command);
        }
        public void UndoLastChangeCommand()
        {
            changeCommands[changeCommands.Count - 1].SetOnlineContext(OnlineContext);
            changeCommands[changeCommands.Count - 1].Undo();
        }
        public void UndoAllChangeCommands()
        {
            changeCommands.ForEach(x => x.SetOnlineContext(OnlineContext));
            changeCommands.ForEach(x => x.Undo());
        }
        public void SyncChangeCommands()
        {
            OnlineContext.Sync();
        }

        public Account CurrentAccount { get; set; }
        public IOnlineContext OnlineContext { get; private set; }
    }
}
