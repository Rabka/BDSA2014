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
        /// <summary>
        /// Sets OnlineContext to be used.
        /// </summary>
        /// <param name="season"></param>
        public void SetOnlineContext(IOnlineContext season)
        {
            onlineContextWasSet = true;
        }
        /// <summary>
        /// Makes the nessesary changes to the database.
        /// </summary>
        public void Execute()
        {
            executeWasCalled ++;
        }
        /// <summary>
        /// ChangeCommand undo is normally supposed to undo the nessesary changes to the database if execute has ever been called.
        /// In the context of how we intend to test the behaviour of Changecommands in general, we will just make a counting to make tests that ensures that
        /// nessesary methods are called only the right amount of times when appropriate methods are called.
        /// </summary>
        public void Undo()
        {
            undoWasCalled++;
        }
    }
}
