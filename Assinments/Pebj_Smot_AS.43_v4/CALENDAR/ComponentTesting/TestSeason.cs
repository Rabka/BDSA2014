using CALENDAR.Storage;
using ComponentTesting.TestStubs.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.Commands;
using System;

namespace ComponentTesting
{
    /// <summary>
    /// Unit testing of Season.
    /// Node: there is no Implamentation of Season so all the tests will fail.
    /// Node: A Complete unit-test with description can be found in TestAccountManagement.cs
    /// </summary>
    [TestClass]
    public class TestSeason
    {
        private ISeason season;

        [TestInitialize]
        public void SetUp()
        {
            season = new Season();
        }

        /// <summary>
        /// As all ChangeCommands are to be treated equally, should there only be two equivalence classes.
        /// this one, where Season gets a ChangeCommands and succeeds.
        /// </summary>
        [TestMethod]
        public void EquivalenceTest_AddChangeCommand()
        {
            try
            {
                season.AddChangeCommand(new ChangeCommandStub());
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex);
            }
        }

        /// <summary>
        /// And this one where Season gets null and throws a Exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Null is not acceptable argument")]
        public void EquivalenceTest_AddChangeCommand2()
        {
            season.AddChangeCommand(null);
        }

        /// <summary>
        /// There are only one Boundary test, at the “edges” of the equivalence classes. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Exception),
            "ChangeCommand allready exists!")]
        public void BoundaryTest_AddChangeCommand()
        {
            var commandStub = new ChangeCommandStub();
            season.AddChangeCommand(commandStub);
            season.AddChangeCommand(commandStub);
        }
    }
}