﻿using CALENDAR.Storage;
using ComponentTesting.TestStubs.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComponentTesting
{
    [TestClass]
    public class TestSeason
    {
        private Season season;

        [TestInitialize]
        public void SetUp(int i)
        {
            season = new Season();
        }

        [TestMethod]
        public void TestEquivalence_AddChangeCommand()
        {
            season.AddChangeCommand(new ChangeCommandStub());
        }

        [TestMethod]
        public void TestPath_SyncChangeCommands()
        {
            var changeCommand = new ChangeCommandStub();
            season.AddChangeCommand(changeCommand);
            season.SyncChangeCommands();
            Assert.AreEqual(1, changeCommand.executeWasCalled);
        }

        [TestMethod]
        public void TestPath_UndoAllChangeCommands()
        {
            var changeCommand1 = new ChangeCommandStub();
            var changeCommand2 = new ChangeCommandStub();
            season.AddChangeCommand(changeCommand1);
            season.AddChangeCommand(changeCommand2);
            season.UndoAllChangeCommands();
            Assert.AreEqual(1, changeCommand1.undoWasCalled);
            Assert.AreEqual(1, changeCommand2.undoWasCalled);
        }

        [TestMethod]
        public void TestPath_UndoAllChangeCommands2()
        {
            var changeCommand1 = new ChangeCommandStub();
            var changeCommand2 = new ChangeCommandStub();
            season.AddChangeCommand(changeCommand1);
            season.AddChangeCommand(changeCommand2);
            season.UndoLastChangeCommand();
            Assert.AreEqual(0, changeCommand1.undoWasCalled);
            Assert.AreEqual(1, changeCommand2.undoWasCalled);
        }

        [TestMethod]
        public void TestPolymorphism_Season()
        {
            season.SyncChangeCommands();
            ((ISeason) season).SyncChangeCommands();
        }
    }
}