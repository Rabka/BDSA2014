using System;
using CALENDAR.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.AccountManagement;
using ComponentTesting.TestStubs.Storage;
namespace ComponentTesting
{
    /// <summary>
    /// This class is a unit test of the AccountManagement class
    /// </summary>
    [TestClass]
    public class TestAccountManagement
    {
        private AccountLogic accountLogic;
        private ISeason seasonStub;
        private Account Maccount;

        [TestInitialize]
        public void SetUp()
        {
            seasonStub = new SeasonStub();
            accountLogic = new AccountLogic(seasonStub);
            //This user is precreated by default in SeasonStub.
            Maccount = new Account("SeaasonStub person", "u", "p", true);
            //Setting CurrentAccount to Maccount enforces that we are logged in as Maccount.
            seasonStub.CurrentAccount = Maccount;           
        }
        /// <summary>
        /// TryCreateAccount - Equivalence test
        /// Tests valid arguments thus no empty arguments. 
        /// </summary>
        [TestMethod]
        public void EquivalenceTest_TryCreateAccount1()
        {
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "andentestmail@gmail.com"));
        }

        /// <summary>
        /// TryCreateAccount - Equivalence test
        /// Tests one invalid argument. 
        /// </summary>
        [TestMethod]
        public void EquivalenceTest_TryCreateAccount2()
        {
            Assert.AreEqual(false, accountLogic.TryCreateAccount(null, "John", "JohnsPassword", "andentestmail@gmail.com"));
        }

        /// <summary>
        /// TryCreateAccount - Equivalence test
        /// Tests inputs with valid input thus no empty arguments. 
        /// </summary>
        [TestMethod]
        public void BoundaryTest_TryCreateAccount()
        {
            Assert.AreEqual(false, accountLogic.TryCreateAccount("","", "", ""));
            Assert.AreEqual(true, accountLogic.TryCreateAccount("n", "u2", "p2", "testmail@gmail.com"));
            //We only test null,null,null,null here and not individually because that is done in the TestPath_TryCreateAccount().
            Assert.AreEqual(false, accountLogic.TryCreateAccount(null, null, null, null));
        }

        /// <summary>
        /// TryCreateAccount - Path test
        /// Tests every if statement of TryCreateAccount
        /// </summary>
        [TestMethod]
        public void TestPath_TryCreateAccount()
        {
            Assert.AreEqual(false, accountLogic.TryCreateAccount(null, "John", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", null, "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", null, "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "StinusPassword", null));

            Assert.AreEqual(false, accountLogic.TryCreateAccount("", "John", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "StinusPassword", ""));

            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "testmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Patrick Von Kleist", "u", "p", "testmail@gmail.com"));
           
            OnlineContextStub o = (OnlineContextStub) (seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);

            Assert.AreEqual(false, accountLogic.TryCreateAccount("seasonstub created person", "new name", "new password", "NewTestmail@gmail.com"));
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
            accountLogic.TryCreateAccount("n","u", "p", "testmail@gmail.com");
            Assert.AreEqual(false, accountLogic.TryLogin("u", "wrongpassword"));
        }

        [TestMethod]
        public void TestPath_TryLogin()
        {
            accountLogic.TryCreateAccount("n","u", "p", "testmail@gmail.com");
            Assert.AreEqual(true, accountLogic.TryLogin("u", "p"));

            Assert.AreEqual(false, accountLogic.TryLogin("", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("u", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("", "p"));

            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
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
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));

            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            accountLogic.TryLogin("Maccount", "Mpassword");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));
        }

        [TestMethod]
        public void TestStateBased_TryRemoveAccount()
        {
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));
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
            seasonStub.CurrentAccount = new Account("NotModerater","u","newemail@",false);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 1);

            seasonStub.CurrentAccount = Maccount;
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
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
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 2);
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 1);
        }
    }
}
