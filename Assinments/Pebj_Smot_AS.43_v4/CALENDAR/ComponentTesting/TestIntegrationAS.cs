using System;
using CALENDAR.AccountManagement;
using CALENDAR.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentTesting.TestStubs.Storage;
namespace ComponentTesting
{
    [TestClass]
    public class TestIntegrationAS
    {
        private AccountLogic accountLogic;
        private ISeason seasonStub;
        private Account Maccount;

        [TestInitialize]
        public void SetUp()
        {
            seasonStub = new SeasonStub();
            accountLogic = new AccountLogic(seasonStub);
            Maccount = new Account("SeaasonStub person", "u", "p", true);
            seasonStub.CurrentAccount = Maccount;
        }

        [TestMethod]
        public void EquivalenceTest_TryCreateAccount()
        {
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "andentestmail@gmail.com"));
        }

        [TestMethod]
        public void BoundaryTest_TryCreateAccount()
        {
            Assert.AreEqual(false, accountLogic.TryCreateAccount("","", "", ""));
            Assert.AreEqual(true, accountLogic.TryCreateAccount("n","u2", "p2", "testmail@gmail.com"));
        }

        [TestMethod]
        public void TestPath_TryCreateAccount()
        {
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "testmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("John Valdemird", "Mu", "p", "testmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("John Valdemird", "u", "p", "Mtestmail@gmail.com"));
        }

        [TestMethod]
        public void EquivalenceTest_TryLogin()
        {
            accountLogic.TryCreateAccount("n","u", "p", "testmail@gmail.com");
            Assert.AreEqual(true, accountLogic.TryLogin("u", "p"));
        }

        [TestMethod]
        public void BoundaryTest_TryLogin()
        {
            accountLogic.TryCreateAccount("n", "u", "p", "testmail@gmail.com");
            Assert.AreEqual(false, accountLogic.TryLogin("u", "wrongpassword"));
        }

        [TestMethod]
        public void TestPath_TryLogin()
        {
            accountLogic.TryCreateAccount("n", "u", "p", "testmail@gmail.com");
            Assert.AreEqual(true, accountLogic.TryLogin("u", "p"));

            Assert.AreEqual(false, accountLogic.TryLogin("", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("u", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("", "p"));
        }

        [TestMethod]
        public void EquivalenceTest_TryRemoveAccount()
        {
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(Maccount));
        }

        [TestMethod]
        public void BoundaryTest_TryRemoveAccount()
        {
            accountLogic.TryCreateAccount("Ole Hansen","Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));
        }

        [TestMethod]
        public void TestPath_TryRemoveAccount()
        {
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole",false)));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));
        }

        [TestMethod]
        public void TestStateBased_TryRemoveAccount()
        {
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));
        }

        [TestMethod]
        public void EquivalenceTest_TryListAccounts()
        {
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 1).Length == 1);
        }

        [TestMethod]
        public void BoundaryTest_TryListAccounts()
        {
            Assert.AreEqual(true, accountLogic.TryListAccounts(1, 0).Length == 0);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 3).Length == 1);
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 3).Length == 2);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 1000).Length == 2);
        }

        [TestMethod]
        public void TestPath_TryListAccounts()
        {
            accountLogic.TryCreateAccount("Ole Hansen", "Ole1", "p", "1newmail@123.com");
            accountLogic.TryCreateAccount("Ole Hansen", "Ole2", "p", "2newmail@123.com");
            accountLogic.TryCreateAccount("Ole Hansen", "Ole3", "p", "3newmail@123.com");

            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 4);
            seasonStub.CurrentAccount = new Account("NotModerater", "u", "newemail@", false);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 1);
        }

        [TestMethod]
        public void EquivalenceTest_TryGetNumberOfAccounts()
        {
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 1);
        }

        [TestMethod]
        public void TestPath_TryGetNumberOfAccounts()
        {
            seasonStub.CurrentAccount = new Account("NotModerater", "u", "newemail@", false);
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 0);
        }
    }
}
