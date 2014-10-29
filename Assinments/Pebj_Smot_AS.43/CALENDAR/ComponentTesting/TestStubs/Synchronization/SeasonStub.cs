using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;
namespace ComponentTesting.TestStubs
{
    class SeasonStub : ISeason
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
    }
}
