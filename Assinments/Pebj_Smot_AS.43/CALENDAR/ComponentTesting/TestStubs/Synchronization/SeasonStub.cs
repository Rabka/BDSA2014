using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;
namespace ComponentTesting.TestStubs
{
    public class SeasonStub : ISeason
    {
        public SeasonStub()
        {

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

        public Account CurrentAccount { get; set; }
        public OnlineContext OnlineContext { get; private set; } // man skal have OnlineContextStub istedet når man bruger get
        public OnlineContextStub OnlineContextStub { get; private set; }
    }
}
