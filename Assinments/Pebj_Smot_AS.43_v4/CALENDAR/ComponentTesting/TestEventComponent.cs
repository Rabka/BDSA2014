using System;
using CALENDAR.AccountManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.EventManagement;

namespace ComponentTesting
{

    /// <summary>
    /// Unit testing of EventComponent.
    /// Node: there is no Implamentation of EventComponent so almost all the tests will fail, 
    /// as EventComponent is a data class and the data is stored in properties, there is implamented.
    /// Node: We have chosen to leave the old test even though they are deficient (especially with testing null as agument).
    /// Node: A Complete unit-test with description can be found in TestAccountManagement.cs
    /// </summary>
    [TestClass]
    public class TestEventComponent
    {

        private EventComponent Event1;
        private EventComponent Event2;
        private EventComponent Event3;
        private EventComponent Event4;
        private EventComponent Event5;
        private EventComponent Event6;

        Account kim;
        Account ole;
        Account pia;

        [TestInitialize]
        public void SetUp()
        {
            kim = new Account("Kim", "Kim", "123@123.123", false);
            ole = new Account("Ole", "Ole", "123@123.123", false);
            pia = new Account("Pia", "Pia", "123@123.123", false);

            EventComponent[] events = new EventComponent[5];
            events[0] = new EventLeaf("Event1", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), kim, new Account[] { }, new INotification[] { });
            events[1] = new EventLeaf("", "", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-11"), ole, new[] { kim}, new INotification[] { new Notification(DateTime.Parse("11-11-9"), false)});
            events[2] = new EventLeaf("Event3", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), kim, new[] { kim, ole}, new INotification[] { });
            events[3] = new EventLeaf("Event4", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), ole, new[] { kim, ole, pia }, new INotification[] { });
            events[4] = new EventLeaf("Event5", "A description", DateTime.Parse("11-11-9"), DateTime.Parse("11-11-13"), pia, new Account[] { }, new INotification[] { new Notification(DateTime.Parse("11-11-9"), false)});

            Event1 = events[0];
            Event2 = events[1];

            EventComposite e1 = new EventComposite("Compo1", "A grup description",kim);
            e1.eventComponents = new EventComponent[] {events[0], events[1]};
            Event3 = e1;

            EventComposite e2 = new EventComposite("Compo2", "A grup description", ole);
            e2.eventComponents = new EventComponent[] {};
            Event4 = e2;

            EventComposite e3 = new EventComposite("Compo3", "A grup description", kim);
            e3.eventComponents = new EventComponent[] { events[0], events[1], events[2], events[3], events[4] };
            Event5 = e3;

            EventComposite e4 = new EventComposite("Compo4", "A grup description2", pia);
            e4.eventComponents = new EventComponent[] { e1, e3 };
            Event6 = e4;
        }

        [TestMethod]
        public void EquivalenceTest_GetLeafs()
        {
            Assert.AreEqual(Event1, Event1.GetLeafs()[0]);
            Assert.AreEqual(Event2, Event2.GetLeafs()[0]);
            Assert.AreEqual(Event2, Event3.GetLeafs()[1]);
            Assert.AreEqual(Event1, Event5.GetLeafs()[0]);
            Assert.AreEqual(Event2, Event5.GetLeafs()[1]);
            Assert.AreEqual(true, Event6.GetLeafs().Length == 7);
        }

        [TestMethod]
        public void BoundaryTest_GetLeafs()
        {
            EventComponent e = new EventComposite("t","d",ole);
            Assert.AreEqual(true, e.GetLeafs().Length == 0);
            Assert.AreEqual(true, Event4.GetLeafs().Length == 0);
            Assert.AreEqual(true, Event5.GetLeafs().Length == 5);
        }

        [TestMethod]
        public void StateBasedTest_GetLeafs()
        {
            Assert.AreEqual(true, Event1.SharedWithAccounts.Length == 0);
            Assert.AreEqual(true, Event2.SharedWithAccounts.Length > 0);
        }

        [TestMethod]
        public void EquivalenceTest_IsLeaf()
        {
            Assert.AreEqual(true, Event1.IsLeaf());
            Assert.AreEqual(false, Event3.IsLeaf());
            Assert.AreEqual(false, Event6.IsLeaf());
        }

        [TestMethod]
        public void BoundaryTest_IsLeaf()
        {
            Assert.AreEqual(true, new EventLeaf("t","t",DateTime.Now,DateTime.Now,new Account("t","t","t",false),new Account[] {}, new INotification[] {}  ));
            Assert.AreEqual(false, Event6.IsLeaf());
        }

        [TestMethod]
        public void EquivalenceTest_DateFrom()
        {
            Assert.AreEqual(DateTime.Parse("11-11-11"), Event1.DateFrom);
            Assert.AreEqual(DateTime.Parse("11-11-10"), Event3.DateFrom);
        }

        [TestMethod]
        public void BoundaryTest_DateFrom()
        {
            Assert.AreEqual(DateTime.Parse("11-11-9"), Event6.DateFrom);
        }

        [TestMethod]
        public void EquivalenceTest_DateTo()
        {
            Assert.AreEqual(DateTime.Parse("11-11-12"), Event1.DateTo);
            Assert.AreEqual(DateTime.Parse("11-11-12"), Event3.DateTo);
        }

        [TestMethod]
        public void BoundaryTest_DateTo()
        {
            Assert.AreEqual(DateTime.Parse("11-11-13"), Event6.DateTo);
        }

        [TestMethod]
        public void EquivalenceTest_SharedWithAccounts()
        {
            Assert.AreEqual(Event1.OwnedByAccount,Event2.SharedWithAccounts[0]);
            Assert.AreEqual(true, Event3.SharedWithAccounts.Length == 0);
        }

        [TestMethod]
        public void BoundaryTest_SharedWithAccounts()
        {
            Assert.AreEqual(true, Event3.SharedWithAccounts.Length == 0);
        }

        [TestMethod]
        public void EquivalenceTest_Notifications()
        {
            Assert.AreEqual(true, Event1.Notifications.Length == 0);
            Assert.AreEqual(true, Event2.Notifications.Length == 1);
            Assert.AreEqual(true, Event3.Notifications.Length == 1);
        }

        [TestMethod]
        public void BoundaryTest_Notifications()
        {
            Assert.AreEqual(true, Event6.Notifications.Length == 2);
        }

        [TestMethod]
        public void EquivalenceTest_Title()
        {
            Assert.AreEqual("Event1", Event1.Title);
            Assert.AreEqual("Compo1", Event3.Title);
        }

        [TestMethod]
        public void BoundaryTest_Title()
        {
            Assert.AreEqual("", Event2.Title);
            Assert.AreEqual("Compo4", Event6.Title);
        }

        [TestMethod]
        public void EquivalenceTest_Description()
        {
            Assert.AreEqual("A description", Event1.Description);
            Assert.AreEqual("A grup description", Event3.Description);
        }

        [TestMethod]
        public void BoundaryTest_Description()
        {
            Assert.AreEqual("", Event2.Description);
            Assert.AreEqual("A grup description2", Event6.Description);
        }

        [TestMethod]
        public void EquivalenceTest_OwnedByAccount()
        {
            Assert.AreEqual(kim, Event1.OwnedByAccount);
            Assert.AreEqual(kim, Event3.OwnedByAccount);
        }

        [TestMethod]
        public void BoundaryTest_OwnedByAccount()
        {
            Assert.AreEqual(ole, Event2.OwnedByAccount);
            Assert.AreEqual(pia, Event6.OwnedByAccount);
        }
    }
}
