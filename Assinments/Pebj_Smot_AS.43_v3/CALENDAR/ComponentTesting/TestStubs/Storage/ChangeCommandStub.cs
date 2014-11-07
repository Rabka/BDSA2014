using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.Storage;
namespace ComponentTesting.TestStubs.Storage
{
    class ChangeCommandStub : IChangeCommand
    {
        public int executeWasCalled = 0;
        public int undoWasCalled = 0;
        public bool onlineContextWasSet = false;
        public void SetOnlineContext(IOnlineContext season)
        {
            onlineContextWasSet = true;
        }
        public void Execute()
        {
            executeWasCalled ++;
        }
        public void Undo()
        {
            undoWasCalled++;
        }
    }
}
