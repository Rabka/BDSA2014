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
        /// Equivalence classes:
        /// - All aguments valid.
        /// - An sigle agument is Null. (as non of the aguments may be Null)
        ///             in PathTest_TryCreateAccount() all aguments are tested with Null.
        /// - An sigle agument is "". (as non of the aguments may be "")
        ///             in PathTest_TryCreateAccount() all aguments are tested with "".
        /// - Either username or E-mail is taken. (as either of username or E-mail may be used before)
        ///             in PathTest_TryCreateAccount() thay are both tested.
        /// - With a invalid email.
        /// 
        /// There are no restrictions on password/username complexity/lengths,
        ///     because we have not yet implemented the database.
        /// </summary>
        [TestMethod]
        public void TryCreateAccount_EquivalenceTest()
        {
            //We have added Console.WriteLine to see where the test fails
            Console.WriteLine("All aguments valid.");
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "andentestmail@gmail.com"));

            Console.WriteLine("An sigle agument is Null. (as non of the aguments may be Null)");
            Assert.AreEqual(false, accountLogic.TryCreateAccount(null, "John2", "JohnsPassword2", "andentestmail@gmail.com2"));

            Console.WriteLine("An sigle agument is \"\". (as non of the aguments may be \"\")");
            Assert.AreEqual(false, accountLogic.TryCreateAccount("", "John3", "JohnsPassword3", "andentestmail@gmail.com3"));

            Console.WriteLine("Either username or E-mail is taken. (as either of username or E-mail may be used before)");
            Assert.AreEqual(false, accountLogic.TryCreateAccount("UserName exist->", "John", "JohnsPassword4", "andentestmail@gmail.com4"));

            Console.WriteLine("With a invalid email.");
            Assert.AreEqual(false, accountLogic.TryCreateAccount("John Valdemird2", "John2", "JohnsPassword2", "email"));
        }

        /// <summary>
        /// TryCreateAccount - Boundary test
        /// As most null/"" aguments are tested in EquivalenceTest_TryCreateAccount() and PathTest_TryCreateAccount(),
        /// the boundery left is with multible Null and "".
        /// 
        /// As there are no restrictions on password/username/email complexity/lengths,
        /// the boundery for thad is minimal and a large enough arguments.
        /// 
        /// As an account can be created,
        /// the boundery is becouse an account can not be created twice.
        /// </summary>
        [TestMethod]
        public void TryCreateAccount_BoundaryTest()
        {
            Console.WriteLine("All aguments as Null or \"\"");
            Assert.AreEqual(false, accountLogic.TryCreateAccount("","", "", ""));
            Assert.AreEqual(false, accountLogic.TryCreateAccount(null, null, null, null));

            Console.WriteLine("With minimal aguments");
            Assert.AreEqual(true, accountLogic.TryCreateAccount("n", "u", "p", "t@m.com"));

            Console.WriteLine("With large aguments");
            Assert.AreEqual(true, accountLogic.TryCreateAccount("nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn", 
                                                                "uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu", 
                                                                "ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp", 
                                                                "ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt@m.com"));

            Console.WriteLine("Try create taken accounts");
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "andentestmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "andentestmail@gmail.com"));
            //We only test null,null,null,null here and not individually because that is done in the TestPath_TryCreateAccount().
        }

        /// <summary>
        /// TryCreateAccount - Path test
        /// Tests every if statement of TryCreateAccount
        /// </summary>
        [TestMethod]
        public void TryCreateAccount_PathTest()
        {
            Console.WriteLine("With individually aguments as Null");
            Assert.AreEqual(false, accountLogic.TryCreateAccount(null, "John", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", null, "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", null, "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "StinusPassword", null));

            Console.WriteLine("With individually aguments as \"\"");
            Assert.AreEqual(false, accountLogic.TryCreateAccount("", "John", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "StinusPassword", ""));

            Console.WriteLine("With individually aguments there are used before");
            Assert.AreEqual(true, accountLogic.TryCreateAccount("John Valdemird", "John", "JohnsPassword", "testmail@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Stinus MT.", "John", "StinusPassword", "stinus@gmail.com"));
            Assert.AreEqual(false, accountLogic.TryCreateAccount("Patrick Von Kleist", "u", "p", "testmail@gmail.com"));

            Console.WriteLine("With out connektion to the server");
            OnlineContextStub o = (OnlineContextStub) (seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);

            Assert.AreEqual(false, accountLogic.TryCreateAccount("seasonstub created person", "new name", "new password", "NewTestmail@gmail.com"));
        }

        [TestMethod]
        public void TryLogin_EquivalenceTest()
        {
            accountLogic.TryCreateAccount("n","u", "p", "testmail@gmail.com");
            Assert.AreEqual(true, accountLogic.TryLogin("u", "p"));
            Assert.AreEqual(false, accountLogic.TryLogin("", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("u", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("", "p"));
            Assert.AreEqual(false, accountLogic.TryLogin("u", null));
            Assert.AreEqual(false, accountLogic.TryLogin(null, "p"));

            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            Assert.AreEqual(false, accountLogic.TryLogin("u", "p"));
            Assert.AreEqual(false, accountLogic.TryLogin("", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("u", ""));
            Assert.AreEqual(false, accountLogic.TryLogin("", "p"));
            Assert.AreEqual(false, accountLogic.TryLogin("u", null));
            Assert.AreEqual(false, accountLogic.TryLogin(null, "p"));
        }

        [TestMethod]
        public void TryLogin_BoundaryTest()
        {
            accountLogic.TryCreateAccount("n","u", "p", "testmail@gmail.com");
            Assert.AreEqual(false, accountLogic.TryLogin("u", "wrongpassword"));
        }

        [TestMethod]
        public void TryRemoveAccount_EquivalenceTest()
        {
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(Maccount));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));

            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            accountLogic.TryLogin("Maccount", "Mpassword");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));
        }

        [TestMethod]
        public void TryRemoveAccount_BoundaryTest()
        {
            accountLogic.TryCreateAccount("Ole Hansen","Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole", false)));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            accountLogic.TryLogin("Ole", "p");
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(Maccount));
        }

        [TestMethod]
        public void TryRemoveAccount_StateBasedTest()
        {
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));

            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            Assert.AreEqual(false, accountLogic.TryRemoveAccount(seasonStub.OnlineContext.GetAccount("Ole")));
        }

        [TestMethod]
        public void TryListAccounts_EquivalenceTest()
        {
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 1).Length == 1);

            accountLogic.TryCreateAccount("Ole Hansen", "Ole1", "p", "1newmail@123.com");
            accountLogic.TryCreateAccount("Ole Hansen", "Ole2", "p", "2newmail@123.com");
            accountLogic.TryCreateAccount("Ole Hansen", "Ole3", "p", "3newmail@123.com");

            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 4);
            seasonStub.CurrentAccount = new Account("NotModerater", "u", "newemail@", false);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 1);

            seasonStub.CurrentAccount = Maccount;
            OnlineContextStub o = (OnlineContextStub)(seasonStub.OnlineContext);
            o.SetOfflineOnlineInterface(false);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 5).Length == 1);
        }

        [TestMethod]
        public void TryListAccounts_BoundaryTest()
        {
            Assert.AreEqual(true, accountLogic.TryListAccounts(1, 0).Length == 0);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 3).Length == 1);
            accountLogic.TryCreateAccount("Ole Hansen", "Ole", "p", "newmail@123.com");
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 3).Length == 2);
            Assert.AreEqual(true, accountLogic.TryListAccounts(0, 1000).Length == 2);
        }

        [TestMethod]
        public void TryGetNumberOfAccounts_EquivalenceTest()
        {
            Assert.AreEqual(true, accountLogic.TryGetNumberOfAccounts() == 1);

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
