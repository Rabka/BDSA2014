using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Commands;
using CALENDAR.Synchronization;
namespace ComponentTesting.TestStubs.Synchronization
{
    class ChangeCommandStub : IChangeCommand
    {
        public int executeWasCalled = 0;
        public int undoWasCalled = 0;
        public void SetSeason(ISeason season)
        {
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
