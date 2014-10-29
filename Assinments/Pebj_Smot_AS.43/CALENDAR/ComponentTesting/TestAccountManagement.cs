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
        [TestMethod]        
        public void TestEquivalence()
        {
            #region Test 1 : TryCreateAccount
            {
                SeasonStub season = new SeasonStub();
                AccountLogic accountLogic = new AccountLogic();
                Assert.AreEqual(false, accountLogic.TryCreateAccount(season, "", "", ""));
                Assert.AreEqual(true, accountLogic.TryCreateAccount(season, "John", "JohnsPassword", "testmail@gmail.com"));
                Assert.AreEqual(false, accountLogic.TryCreateAccount(season, "staticAccount", "JohnsPassword", "testmail@gmail.com"));
            }
            #endregion
            #region Test 2 : TryLogin
            {
                SeasonStub season = new SeasonStub();
                AccountLogic accountLogic = new AccountLogic();
                Assert.AreEqual(false, accountLogic.TryLogin(season, "", ""));
                Assert.AreEqual(false, accountLogic.TryLogin(season, "Johny", "JohnsPassword"));
                Assert.AreEqual(true, accountLogic.TryLogin(season, "staticModerator", "JohnsPassword"));
            }
            #endregion
            #region Test 3 : TryRemoveAccount
            {
                SeasonStub season = new SeasonStub();
                AccountLogic accountLogic = new AccountLogic();
                Account account = new Account("", "", "", false);
                ((DBObject)account).TableID = 1; //SeasonTestStub contains an account by default with a database id of 1.
                Assert.AreEqual(true, accountLogic.TryRemoveAccount(season, account));
            }
            #endregion
            #region Test 4 : TryListAccounts
            {
                //By default, we are logged into a moderator account known as ModeratorAccount.
                SeasonStub season = new SeasonStub();
                AccountLogic accountLogic = new AccountLogic();
                Assert.AreEqual(true, accountLogic.TryListAccounts(season,0,1).Length == 1);
            }
            #endregion
        }

        [TestMethod]
        public void TestBoundary()
        {
            #region Test 1 : TryListAccounts
            {
                //By default, we are logged into a moderator account known as ModeratorAccount.
                SeasonStub season = new SeasonStub();
                AccountLogic accountLogic = new AccountLogic();
                //from cannot be larger than to
                Assert.AreEqual(true, accountLogic.TryListAccounts(season, 1, 0).Length == 0);
                //Length cannot be larger than the count of entries in the database.
                Assert.AreEqual(true, accountLogic.TryListAccounts(season, 0, 3).Length == 2);
            }
            #endregion
            #region Test 2 : TryGetNumberOfAccounts
            {
                //By default, we are logged into a moderator account known as ModeratorAccount.
                SeasonStub season = new SeasonStub();
                AccountLogic accountLogic = new AccountLogic();
                //from cannot be larger than to.
                Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts(season) == 2);
            }
            #endregion

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
