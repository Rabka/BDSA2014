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
