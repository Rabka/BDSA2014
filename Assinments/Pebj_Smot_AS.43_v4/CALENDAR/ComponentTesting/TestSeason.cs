using CALENDAR.Storage;
using ComponentTesting.TestStubs.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.Commands;
using System;

namespace ComponentTesting
{
    [TestClass]
    public class TestSeason
    {
        private Season season;

        [TestInitialize]
        public void SetUp()
        {
            season = new Season();
        }

        [TestMethod]
        public void TestEquivalence_AddChangeCommand()
        {
            try
            {
                season.AddChangeCommand(new ChangeCommandStub());
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Null is not acceptable argument")]
        public void TestEquivalence_AddChangeCommand2()
        {
            season.AddChangeCommand(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception),
            "ChangeCommand allready exists!")]
        public void TestBoundary_AddChangeCommand()
        {
                ChangeCommandStub commandStub = new ChangeCommandStub();
                season.AddChangeCommand((IChangeCommand)commandStub);
                season.AddChangeCommand(commandStub);
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
        public void TestPolymorphism_Season()
        {
            try
            {
            season.SyncChangeCommands();
            ((ISeason) season).SyncChangeCommands();
            }
            catch (Exception ex)
            {
                   Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void TestPolymorphism_AddChangeCommand()
        {
            ChangeCommandStub commandStub = new ChangeCommandStub();
            season.AddChangeCommand((IChangeCommand)commandStub);
            season.SyncChangeCommands();
            Assert.AreEqual(1, commandStub.executeWasCalled);
        }
    }
}