using System;
using CALENDAR.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.AccountManagement;
using ComponentTesting.TestStubs;
namespace ComponentTesting
{
    /// <summary>
    /// This class is a unit test of the AccountManagement class
    /// </summary>
    [TestClass]
    public class TestAccountManagement
    {
        private AccountLogic accountLogic;
        private SeasonStub seasonStub;
        private Account Maccount;

        [TestInitialize]
        public void SetUp(int i)
        {
            seasonStub = new SeasonStub();
            accountLogic = new AccountLogic(seasonStub);


            Maccount = new Account("Maccount", "u", "Mtestmail@gmail.com", true);
            seasonStub.CurrentAccount = Maccount;
            accountLogic.TryCreateAccount("Maccount", "Mpassword", "Mtestmail@gmail.com");
            accountLogic = new AccountLogic(seasonStub);
        }

//        public int TryGetNumberOfAccounts()

        [TestMethod]
        public void EquivalenceTest_TryCreateAccount()
        {
            Assert.AreEqual(true, accountLogic.TryCreateAccount( "John", "JohnsPassword", "andentestmail@gmail.com"));
        }
        [TestMethod]
        public void BoundaryTest_TryCreateAccount()
        {
            Assert.AreEqual(false, accountLogic.TryCreateAccount("", "", ""));
            Assert.AreEqual(true, accountLogic.TryCreateAccount("u", "p", "testmail@gmail.com"));
        }

        [TestMethod]
        public void TestPath_TryCreateAccount()
        {
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John", "JohnsPassword", "testmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Mu", "p", "testmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("u", "p", "Mtestmail@gmail.com"));

            OnlineContextStub o = (OnlineContextStub) (seasonStub.OnlineContext);
            o.IsOnlineToFalse();
            Assert.AreEqual(false, accountLogic.TryCreateAccount("new name", "new password", "NewTestmail@gmail.com"));
        }

        [TestMethod]
        public void EquivalenceTest_TryLogin()
        {
            accountLogic.TryCreateAccount("u", "p", "testmail@gmail.com");
            Assert.AreEqual(true, accountLogic.TryLogin("u", "p"));
        }

        [TestMethod]
        public void BoundaryTest_TryLogin()
        {
            accountLogic.TryCreateAccount("u", "p", "testmail@gmail.com");
            Assert.AreEqual(false, accountLogic.TryLogin("u", "wrongpassword"));
        }

        [TestMethod]
        public void TestPath_TryLogin()
        {
            accountLogic.TryCreateAccount("u", "p", "testmail@gmail.com");
            Assert.AreEqual(true, accountLogic.TryLogin("u", "p"));

            Assert.AreEqual(false, accountLogic.TryLogin("", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("u", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("", "p"));

            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.IsOnlineToFalse();
            Assert.AreEqual(false, accountLogic.TryLogin("u", "p"));
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
            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));

            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));
        }

        [TestMethod]
        public void TestPath_TryRemoveAccount()
        {
            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));

            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));

            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.IsOnlineToFalse();
            accountLogic.TryLogin("Maccount", "Mpassword");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));
        }

        [TestMethod]
        public void TestStateBased_TryRemoveAccount()
        {
            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));

            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.IsOnlineToFalse();
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));
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
            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 3).Length == 2);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 1000).Length == 2);
        }

        [TestMethod]
        public void TestPath_TryListAccounts()
        {
            accountLogic.TryCreateAccount("Ole1", "p", "1newmail@123.com");
            accountLogic.TryCreateAccount("Ole2", "p", "2newmail@123.com");
            accountLogic.TryCreateAccount("Ole3", "p", "3newmail@123.com");

            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 4);
            seasonStub.CurrentAccount = new Account("NotModerater","u","newemail@",false);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 1);

            seasonStub.CurrentAccount = Maccount;
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.IsOnlineToFalse();
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

            seasonStub.CurrentAccount = Maccount;
            accountLogic.TryCreateAccount("Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 2);
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.IsOnlineToFalse();
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 1);
        }
    }
}
