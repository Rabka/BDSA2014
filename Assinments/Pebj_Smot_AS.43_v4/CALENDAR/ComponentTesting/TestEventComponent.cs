using System;
using CALENDAR.AccountManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.EventManagement;

namespace ComponentTesting
{

    /// <summary>
    /// Unit testing of EventComponent.
    /// Node: We have chosen to leave the old test even though they are deficient (especially with testing null as agument).
    /// Node: A Complete unit-test with description can be found in TestAccountManagement.cs and this class.
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

            EventComposite e1 = new EventComposite("Compo1", "A grup description",kim, new IAccount[0]);
            e1.eventComponents = new EventComponent[] {events[0], events[1]};
            Event3 = e1;

            EventComposite e2 = new EventComposite("Compo2", "A grup description", ole, new IAccount[0]);
            e2.eventComponents = new EventComponent[] {};
            Event4 = e2;

            EventComposite e3 = new EventComposite("Compo3", "A grup description", kim, new IAccount[0]);
            e3.eventComponents = new EventComponent[] { events[0], events[1], events[2], events[3], events[4] };
            Event5 = e3;

            EventComposite e4 = new EventComposite("Compo4", "A grup description2", pia, new IAccount[0]);
            e4.eventComponents = new EventComponent[] { e1, e3 };
            Event6 = e4;

        }
        /// <summary>
        /// Equivalence test of GetLeafs.
        /// We expect to get any leaf that can be recursively found from
        /// an EventComposite' EventComponent[] eventComponents.
        /// We also expect that leafs are returned in the order they were added.
        /// </summary>
        [TestMethod]
        public void GetLeafs_EquivalenceTest()
        {
            Assert.AreEqual(Event1, Event1.GetLeafs()[0]);
            Assert.AreEqual(Event2, Event2.GetLeafs()[0]);
            Assert.AreEqual(Event2, Event3.GetLeafs()[1]);
            Assert.AreEqual(Event1, Event5.GetLeafs()[0]);
            Assert.AreEqual(Event2, Event5.GetLeafs()[1]);
            Assert.AreEqual(true, Event6.GetLeafs().Length == 7);
        }

        /// <summary>
        /// Boundary test of GetLeafs
        /// We expect the GetLeafs boundaries of our EventComposites created in SetUp to reflect the exact number of underlying leafs.
        /// </summary>
        [TestMethod]
        public void GetLeafs_BoundaryTest()
        {
            EventComponent e = new EventComposite("t", "d", ole, new IAccount[0]);
            Assert.AreEqual(true, e.GetLeafs().Length == 0);
            Assert.AreEqual(true, Event4.GetLeafs().Length == 0);
            Assert.AreEqual(true, Event5.GetLeafs().Length == 5);
        }


        /// <summary>
        /// Equivalence test of IsLead
        /// We expect only EventLeaf to return true on this methods.
        /// Any other implementation of EventComponent should return false.
        /// </summary>
        [TestMethod]
        public void IsLeaf_EquivalenceTest()
        {
            Assert.AreEqual(true, Event1.IsLeaf());
            Assert.AreEqual(false, Event3.IsLeaf());
            Assert.AreEqual(false, Event6.IsLeaf());
        }

        /// <summary>
        /// Boundary test of IsLeaf()
        /// This tests to see if a new leaf and an old leaf both returns the expected value of IsLeaf. Also this tests
        /// the existing boundaries of IsLeaf to be either false or true in the right case.
        /// </summary>
        [TestMethod]
        public void IsLeaf_BoundaryTest()
        {
            Assert.AreEqual(true, (new EventLeaf("t","t",DateTime.Now,DateTime.Now,new Account("t","t","t",false),new Account[] {}, new INotification[] {} ) ).IsLeaf());
            Assert.AreEqual(false, Event6.IsLeaf());
        }

        /// <summary>
        /// Equivalence tests DateFrom
        /// This tests if the Date we assigned to the events are what they return when asked.
        /// </summary>
        [TestMethod]
        public void DateFrom_EquivalenceTest()
        {
            Assert.AreEqual(DateTime.Parse("11-11-11"), Event1.DateFrom);
            Assert.AreEqual(DateTime.Parse("11-11-10"), Event3.DateFrom);
        }

        /// <summary>
        /// Boundary test DateFrom
        /// This tests if the Date is equals the only value it is allowed to be.
        /// </summary>
        [TestMethod]
        public void DateFrom_BoundaryTest()
        {
            Assert.AreEqual(DateTime.Parse("11-11-9"), Event6.DateFrom);
        }

        /// <summary>
        /// Equivalence tests DateFrom
        /// This tests if the Date we assigned to the events are what they return when asked.
        /// </summary>
        [TestMethod]
        public void DateTo_EquivalenceTest()
        {
            Assert.AreEqual(DateTime.Parse("11-11-12"), Event1.DateTo);
            Assert.AreEqual(DateTime.Parse("11-11-12"), Event3.DateTo);
        }

        /// <summary>
        /// Boundary test DateTo
        /// This tests if the Date is equals the only value it is allowed to be.
        /// </summary>
        [TestMethod]
        public void DateTo_BoundaryTest()
        {
            Assert.AreEqual(DateTime.Parse("11-11-13"), Event6.DateTo);
        }

        /// <summary>
        /// Equivalence tests SharedWithAccounts
        /// This tests if the Account we assigned to the SharedWithAccounts are what is returned when asked.
        /// </summary>
        [TestMethod]
        public void SharedWithAccounts_EquivalenceTest()
        {
            Assert.AreEqual(Event1.OwnedByAccount,Event2.SharedWithAccounts[0]);
            Assert.AreEqual(true, Event3.SharedWithAccounts.Length == 0);
        }

        /// <summary>
        /// Boundary test SharedWithAccounts
        /// This tests if the Account is equals the only value it is allowed to be.
        /// </summary>
        [TestMethod]
        public void SharedWithAccounts_BoundaryTest()
        {
            Assert.AreEqual(true, Event3.SharedWithAccounts.Length == 0);
        }
        /// <summary>
        /// Equivalence tests Notifications
        /// This tests if the Amount of notifications correspond to the Notifications we added in SetUp.
        /// </summary>
        [TestMethod]
        public void Notifications_EquivalenceTest()
        {
            Assert.AreEqual(true, Event1.Notifications.Length == 0);
            Assert.AreEqual(true, Event2.Notifications.Length == 1);
            Assert.AreEqual(true, Event3.Notifications.Length == 1);
        }

        /// <summary>
        /// Boundary test Notifications
        /// This tests if the boundary of Notifications is equals to the number of Notifications added in SetUp.
        /// </summary>
        [TestMethod]
        public void Notifications_BoundaryTest()
        {
            Assert.AreEqual(true, Event6.Notifications.Length == 3);
        }

        /// <summary>
        /// Equivalence tests Title
        /// This tests if the Title we assigned to the Event is what is returned when asked.
        /// </summary>
        [TestMethod]
        public void Title_EquivalenceTest()
        {
            Assert.AreEqual("Event1", Event1.Title);
            Assert.AreEqual("Compo1", Event3.Title);
        }

        /// <summary>
        /// Boundary tests Title
        /// This tests if the Title we assigned to the Event is an allowed value.
        /// </summary>
        [TestMethod]
        public void Title_BoundaryTest()
        {
            Assert.AreEqual("", Event2.Title);
            Assert.AreEqual("Compo4", Event6.Title);
        }

        /// <summary>
        /// Boundary tests Description
        /// This tests if the Description we assigned to the Event is what is returned when asked.
        /// </summary>
        [TestMethod]
        public void Description_EquivalenceTest()
        {
            Assert.AreEqual("A description", Event1.Description);
            Assert.AreEqual("A grup description", Event3.Description);
        }


        /// <summary>
        /// Boundary tests Description
        /// This tests if the Description we assigned to the Event is an allowed value.
        /// </summary>
        [TestMethod]
        public void Description_BoundaryTest()
        {
            Assert.AreEqual("", Event2.Description);
            Assert.AreEqual("A grup description2", Event6.Description);
        }


        /// <summary>
        /// Boundary test OwnedByAccount
        /// This tests if the Account we assigned to the OwnedByAccount are what is returned when asked.
        /// </summary>
        [TestMethod]
        public void OwnedByAccount_EquivalenceTest()
        {
            Assert.AreEqual(kim, Event1.OwnedByAccount);
            Assert.AreEqual(kim, Event3.OwnedByAccount);
        }

        /// <summary>
        /// Boundary test OwnedByAccount
        /// This tests if the Account is equals the only value it is allowed to be.
        /// </summary>
        [TestMethod]
        public void OwnedByAccount_BoundaryTest()
        {
            Assert.AreEqual(ole, Event2.OwnedByAccount);
            Assert.AreEqual(pia, Event6.OwnedByAccount);
        }

        /// <summary>
        /// EventComponent interface has two classes that implements it.
        /// EventComposite and EventLeaf. Both of these must both implement and have
        /// the same expected responce in terms of the property Notification.
        /// </summary>
        [TestMethod]
        public void EventComponentAndLeaf_PolymorphismTest()
        {
            Assert.AreEqual(true, Event6.Notifications.Length == 3);
            Assert.AreEqual(true, ((EventComposite)Event6).Notifications.Length == 3);
            Assert.AreEqual(true,( (EventComposite)((EventComposite)Event6).eventComponents[0]).eventComponents[1].Notifications.Length == 1);    
        }
    }
}
