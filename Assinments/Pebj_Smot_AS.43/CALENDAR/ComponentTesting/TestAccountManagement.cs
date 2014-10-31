using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;
using ComponentTesting.TestStubs;
namespace ComponentTesting
{
    [TestClass]
    public class TestAccountManagement
    {
        private AccountLogic accountLogic;
        private SeasonStub seasonStub;

        [TestInitialize]
        public void SetUp(int i)
        {
            seasonStub = new SeasonStub();
            seasonStub.CurrentAccount = new Account("account", "u", "e", true);
            accountLogic = new AccountLogic(seasonStub);
        }

        [TestMethod]
        public void EquivalenceTest_TryCreateAccount()
        {
                Assert.AreEqual(false, accountLogic.TryCreateAccount( "", "", ""));
                Assert.AreEqual(true, accountLogic.TryCreateAccount( "John", "JohnsPassword", "testmail@gmail.com"));
                Assert.AreEqual(false, accountLogic.TryCreateAccount( "u", "e", "testmail@gmail.com"));
        }
        [TestMethod]
        public void EquivalenceTest_TryLogin()
        {
                Assert.AreEqual(false, accountLogic.TryLogin("", ""));
                Assert.AreEqual(false, accountLogic.TryLogin("u", "wrongpassword"));
                Assert.AreEqual(true, accountLogic.TryLogin("u", "e"));
        }
         [TestMethod]
        public void EquivalenceTest_TryRemoveAccount()
        {
                Account account = new Account("", "", "", false);
                ((DBObject)account).TableID = 1; //SeasonTestStub contains an account by default with a database id of 1.
                Assert.AreEqual(true, accountLogic.TryRemoveAccount(account));
        }
         [TestMethod]
         public void EquivalenceTest_TryRemoveAccount()
         {
                 //By default, we are logged into a moderator account known as ModeratorAccount.
                 Assert.AreEqual(true, accountLogic.TryListAccounts(0, 1).Length == 1);
         }

        [TestMethod]
         public void BoundaryTest_TryListAccounts()
        {
                //By default, we are logged into a moderator account known as ModeratorAccount.
                //from cannot be larger than to
                Assert.AreEqual(true, accountLogic.TryListAccounts(1, 0).Length == 0);
                //Length cannot be larger than the count of entries in the database.
                Assert.AreEqual(true, accountLogic.TryListAccounts(0, 3).Length == 2);
        }
        [TestMethod]
        public void BoundaryTest_TryGetNumberOfAccounts()
        {
                //By default, we are logged into a moderator account known as ModeratorAccount.
                //from cannot be larger than to.
                Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 2);
        }

        [TestMethod]
        public void TestPath()
        {

        }
        [TestMethod]
        public void TestStateBased()
        {

        }
        [TestMethod]
        public void TestPolymorphism()
        {

        }
    }
}
