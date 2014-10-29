using System;
using CALENDAR.AccountManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CALENDAR.EventManagement;

namespace ComponentTesting
{
    [TestClass]
    public class TestEventComponent
    {

        private EventComponent Event1;
        private EventComponent Event2;
        private EventComponent Event3;
        private EventComponent Event4;
        private EventComponent Event5;

        [TestInitialize]
        public void SetUp()
        {
            Account kim = new Account("Kim", "Kim", "123@123.123", false);
            Account ole = new Account("Ole", "Ole", "123@123.123", false);
            Account pia = new Account("Pia", "Pia", "123@123.123", false);

            EventComponent[] events = new EventComponent[5];
            events[0] = new EventLeaf("Event1", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), kim, new Account[] { }, new INotification[] { });
            events[1] = new EventLeaf("Event2", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), ole, new[] { kim}, new INotification[] { });
            events[2] = new EventLeaf("Event3", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), kim, new[] { kim, ole}, new INotification[] { });
            events[3] = new EventLeaf("Event4", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), ole, new[] { kim, ole, pia }, new INotification[] { });
            events[4] = new EventLeaf("Event5", "A description", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), pia, new Account[] { }, new INotification[] { new Notification(DateTime.Parse("11-11-9"), false)});

            Event1 = events[0];
            Event2 = events[1];
            EventsComposite e = new EventsComposite();
            e.eventComponents = new EventComponent[] {events[0], events[1]};
            Event3 = e;
            e.eventComponents = new EventComponent[] { events[2], events[3], events[4] };
            Event4 = e;
            e.eventComponents = new EventComponent[] { events[0], events[1], events[2], events[3], events[4] };
            Event5 = e;
        }

        [TestMethod]
        public void EquivalenceTest_GetLeafs()
        {
            Assert.AreEqual(Event1, Event1.GetLeafs());
        }

        [TestMethod]
        public void BoundaryTest_GetLeafs()
        {
        }

        [TestMethod]
        public void PathTest_GetLeafs()
        {
        }

        [TestMethod]
        public void StateBasedTest_GetLeafs()
        {
        }

        [TestMethod]
        public void PolymorphismTest_GetLeafs()
        {
        }

        [TestMethod]
        public void EquivalenceTest_IsLeaf()
        {
        }

        [TestMethod]
        public void BoundaryTest_IsLeaf()
        {
        }

        [TestMethod]
        public void PathTest_IsLeaf()
        {
        }

        [TestMethod]
        public void StateBasedTest_IsLeaf()
        {
        }

        [TestMethod]
        public void PolymorphismTest_IsLeaf()
        {
        }
    }
}
