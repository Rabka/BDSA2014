﻿using System;
using System.Linq;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
using ComponentTesting.TestStubs.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ComponentTesting
{
    /// <summary>
    /// Unit testing of EventLogic.
    /// Node: there is no Implamentation of EventLogic so all the tests will fail.
    /// Node: We have chosen to leave the old test even though they are deficient (especially with testing null as agument).
    /// Node: A Complete unit-test with description can be found in TestAccountManagement.cs
    /// </summary>
    [TestClass]
    public class TestEventLogic
    {
        private EventLogic eventLogic;
        private SeasonStub seasonStub;

        [TestInitialize]
        public void SetUp()
        {
            seasonStub = new SeasonStub();
            seasonStub.CurrentAccount = new Account("account", "u", "e", false);
            eventLogic = new EventLogic(seasonStub);
        }

        [TestMethod]
        public void EquivalenceTest_AddEvent()
        {
            EventComponent e1 = eventLogic.AddEvent("event1", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),
                                                    new INotification[] {new Notification(DateTime.Parse("11-11-9"), false)});
            Assert.AreEqual(true,e1.TableID != 0);
            Assert.AreEqual(e1.TableID, seasonStub.OnlineContext.GetEventComponent(e1.TableID).TableID);

            EventComponent e2 = eventLogic.AddEvent("event2", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),new INotification[] {});
            Assert.AreEqual(true, e2.TableID != 0);
            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);

            EventComponent e3 = eventLogic.AddEvent("", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),
                                                    new INotification[] { new Notification(DateTime.Parse("11-11-9"), false) });
            Assert.AreEqual(true, e3.TableID != 0);
            Assert.AreEqual(e3.TableID, seasonStub.OnlineContext.GetEventComponent(e3.TableID).TableID);

            EventComponent e4 = eventLogic.AddEvent("event4", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),null);
            Assert.AreEqual(true, e4.TableID != 0);
            Assert.AreEqual(e4.TableID, seasonStub.OnlineContext.GetEventComponent(e4.TableID).TableID);

            try
            {
                eventLogic.AddEvent(null, DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), new INotification[] { });
                Assert.Fail("Expected an exception");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void BoundaryTest_AddEvent()
        {
            EventComponent e = eventLogic.AddEvent("", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),
                                                    new INotification[] { new Notification(DateTime.Parse("11-11-9"), false) });
            Assert.AreEqual(true, e.TableID != 0);
            Assert.AreEqual(e.TableID, seasonStub.OnlineContext.GetEventComponent(e.TableID).TableID);

            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), null);
            Assert.AreEqual(true, e2.TableID != 0);
            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);

            try
            {
                eventLogic.AddEvent(null, DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), new INotification[] { });
                Assert.Fail("Expected an exception");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);

                try
                {
                    eventLogic.AddEvent("e", DateTime.Parse("11-11-15"), DateTime.Parse("11-11-10"), new INotification[] { });
                    Assert.Fail("Expected an exception");
                }
                catch (Exception)
                {
                    Assert.IsTrue(true);
                }
            }
        }

        [TestMethod]
        public void EquivalenceTest_GetEventById()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),
                                                    new INotification[] { new Notification(DateTime.Parse("11-11-9"), false) });
            Assert.AreEqual(e.TableID, eventLogic.GetEventById(e.TableID.ToString()).TableID);
            Assert.AreEqual(e.TableID, seasonStub.OnlineContext.GetEventComponent(e.TableID).TableID);
        }

        [TestMethod]
        public void BoundaryTest_GetEventById()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), null);
            Assert.AreEqual(e.TableID, eventLogic.GetEventById(e.TableID.ToString()).TableID);
            Assert.AreEqual(e.TableID, seasonStub.OnlineContext.GetEventComponent(e.TableID).TableID);

            EventComponent e2 = eventLogic.AddEvent("", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),
                                                    new INotification[] { new Notification(DateTime.Parse("11-11-9"), false) });
            Assert.AreEqual(e2.TableID, eventLogic.GetEventById(e2.TableID.ToString()).TableID);
            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);
        }

        [TestMethod]
        public void PolymorphismTest_GetEventById()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), null);

            Assert.AreEqual(e.TableID, eventLogic.GetEventById(e.TableID.ToString()).TableID);
            Assert.AreEqual(e.TableID, seasonStub.OnlineContext.GetEventComponent(e.TableID).TableID);

            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"),
                                                    new INotification[] { new Notification(DateTime.Parse("11-11-9"), false) });
            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e, e2);

            Assert.AreEqual(ec.TableID, eventLogic.GetEventById(ec.TableID.ToString()).TableID);
            Assert.AreEqual(ec.TableID, seasonStub.OnlineContext.GetEventComponent(ec.TableID).TableID);
        }

        [TestMethod]
        public void EquivalenceTest_GetEvents()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), null);

            EventComponent[] es = eventLogic.GetEvents(DateTime.Parse("11-11-10"), DateTime.Parse("11-11-12"));

            Assert.AreEqual(true, es.Select(x => x).Count(x => x.Title == "e1") == 1);
            Assert.AreEqual(true, es.Select(x => x).Count(x => x.Title == "e2") == 1);
        }

        [TestMethod]
        public void BoundaryTest_GetEvents()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"), null);
            EventComponent e3 = eventLogic.AddEvent("e3", DateTime.Parse("11-11-12"), DateTime.Parse("11-11-12"), null);

            EventComponent[] ec1 = eventLogic.GetEvents(DateTime.Parse("11-11-9"), DateTime.Parse("11-11-11"));
            EventComponent[] ec2 = eventLogic.GetEvents(DateTime.Parse("11-11-11"), DateTime.Parse("11-11-11"));
            EventComponent[] ec3 = eventLogic.GetEvents(DateTime.Parse("11-11-11"), DateTime.Parse("11-11-13"));
            EventComponent[] ec4 = eventLogic.GetEvents(DateTime.Parse("11-11-20"), DateTime.Parse("11-11-21"));

            Assert.AreEqual(true, ec1.Select(x => x).Count(x => x.Title == "e1") == 1);
            Assert.AreEqual(true, ec1.Select(x => x).Count(x => x.Title == "e2") == 1);
            Assert.AreEqual(false, ec1.Select(x => x).Count(x => x.Title == "e3") == 1);

            Assert.AreEqual(false, ec2.Select(x => x).Count(x => x.Title == "e1") == 1);
            Assert.AreEqual(true, ec2.Select(x => x).Count(x => x.Title == "e2") == 1);
            Assert.AreEqual(false, ec2.Select(x => x).Count(x => x.Title == "e3") == 1);

            Assert.AreEqual(false, ec3.Select(x => x).Count(x => x.Title == "e1") == 1);
            Assert.AreEqual(true, ec3.Select(x => x).Count(x => x.Title == "e2") == 1);
            Assert.AreEqual(true, ec3.Select(x => x).Count(x => x.Title == "e3") == 1);

            Assert.AreEqual(false, ec4.Select(x => x).Count(x => x.Title == "e1") == 1);
            Assert.AreEqual(false, ec4.Select(x => x).Count(x => x.Title == "e2") == 1);
            Assert.AreEqual(false, ec4.Select(x => x).Count(x => x.Title == "e3") == 1);

            EventComponent e4 = eventLogic.AddEvent("e4", DateTime.Parse("11-11-9"), DateTime.Parse("11-11-11"), null);
            EventComponent e5 = eventLogic.AddEvent("e5", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-13"), null);

            EventComponent[] ec5 = eventLogic.GetEvents(DateTime.Parse("11-11-10"), DateTime.Parse("11-11-12"));

            Assert.AreEqual(true, ec5.Select(x => x).Count(x => x.Title == "e4") == 1);
            Assert.AreEqual(true, ec5.Select(x => x).Count(x => x.Title == "e5") == 1);

            try
            {
                eventLogic.GetEvents(DateTime.Parse("11-11-11"), DateTime.Parse("11-11-9"));
                Assert.Fail("Expected an exception");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void PolymorphismTest_GetEvents()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-11"), DateTime.Parse("11-11-12"), null);
            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e1);

            EventComponent[] ea1 = eventLogic.GetEvents(DateTime.Parse("11-11-9"), DateTime.Parse("11-11-11"));
            EventComponent[] ea2 = eventLogic.GetEvents(DateTime.Parse("11-11-20"), DateTime.Parse("11-11-21"));

            Assert.AreEqual(true, ea1.Select(x => x).Count(x => x.Title == "ec") == 1);
            Assert.AreEqual(true, ea1.Select(x => x).Count(x => x.Title == "e1") == 1);

            Assert.AreEqual(false, ea2.Select(x => x).Count(x => x.Title == "ec") == 1);
            Assert.AreEqual(false, ea2.Select(x => x).Count(x => x.Title == "e1") == 1);
        }

        [TestMethod]
        public void EquivalenceTest_RemoveEvent()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            Assert.AreEqual(e.TableID, seasonStub.OnlineContext.GetEventComponent(e.TableID).TableID);
            eventLogic.RemoveEvent(e);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(e.TableID) == null);
        }

        [TestMethod]
        public void BoundaryTest_RemoveEvent()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e1, e2);

            Assert.AreEqual(ec, seasonStub.OnlineContext.GetEventComponent(ec.TableID));
            eventLogic.RemoveEvent(ec);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec.TableID) == null);
            Assert.AreEqual(e1.TableID, seasonStub.OnlineContext.GetEventComponent(e1.TableID).TableID);
            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);
        }

        [TestMethod]
        public void PolymorphismTest_RemoveEvent()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e1, e2);

            Assert.AreEqual(e1.TableID, seasonStub.OnlineContext.GetEventComponent(e1.TableID).TableID);
            eventLogic.RemoveEvent(e1);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(e1.TableID) == null);

            Assert.AreEqual(ec.TableID, seasonStub.OnlineContext.GetEventComponent(ec.TableID).TableID);
            eventLogic.RemoveEvent(ec);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec.TableID) == null);

            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);
            eventLogic.RemoveEvent(e2);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(e2.TableID) == null);
        }

        [TestMethod]
        public void EquivalenceTest_UpdateEvent()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            e.Title = "new e";
            eventLogic.UpdateEvent(e);

            Assert.AreEqual("new e", seasonStub.OnlineContext.GetEventComponent(e.TableID).Title);

            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            seasonStub.CurrentAccount = new Account("other account", "u", "e", false);
            e2.Title = "new e2";
            eventLogic.UpdateEvent(e2);

            Assert.AreEqual("new e2", seasonStub.OnlineContext.GetEventComponent(e2.TableID).Title);

            seasonStub.CurrentAccount = new Account("moderator account", "u", "e", true);
            e.Title = "new e";
            eventLogic.UpdateEvent(e);

            Assert.AreEqual("new e", seasonStub.OnlineContext.GetEventComponent(e.TableID).Title);
        }

        [TestMethod]
        public void BoundaryTest_UpdateEvent()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            e.Title = null;
            eventLogic.UpdateEvent(e);

            Assert.AreEqual(null, seasonStub.OnlineContext.GetEventComponent(e.TableID).Title);

            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e);
            ec.Title = "new title";
            eventLogic.UpdateEvent(ec);

            Assert.AreEqual("new title", seasonStub.OnlineContext.GetEventComponent(ec.TableID).Title);
        }

        [TestMethod]
        public void PolymorphismTest_UpdateEvent()
        {
            EventComponent e = eventLogic.AddEvent("e", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            e.Title = null;
            eventLogic.UpdateEvent(e);

            Assert.AreEqual(null, seasonStub.OnlineContext.GetEventComponent(e.TableID).Title);

            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e);
            ec.Title = "new title";
            eventLogic.UpdateEvent(ec);

            Assert.AreEqual("new title", seasonStub.OnlineContext.GetEventComponent(ec.TableID).Title);
        }

        [TestMethod]
        public void EquivalenceTest_JoinComponentsToNewComposite()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec","d",new Account("n","u","e",false), e1, e2);

            Assert.AreEqual(e1.TableID, seasonStub.OnlineContext.GetEventComponent(e1.TableID).TableID);
            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);
            Assert.AreEqual(ec.TableID, seasonStub.OnlineContext.GetEventComponent(ec.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(e1.TableID).GetLeafs()[0].TableID == e1.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(e1.TableID).GetLeafs()[1].TableID == e1.TableID);

            EventComponent e3 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e4 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec1 = eventLogic.JoinComponentsToNewComposite("ec1", "d", new Account("n", "u", "e", false), e3, e4);
            EventComponent e5 = eventLogic.AddEvent("e3", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec2 = eventLogic.JoinComponentsToNewComposite("ec2", "d", new Account("n", "u", "e", false), ec1, e5);

            Assert.AreEqual(e3.TableID, seasonStub.OnlineContext.GetEventComponent(e3.TableID).TableID);
            Assert.AreEqual(e4.TableID, seasonStub.OnlineContext.GetEventComponent(e4.TableID).TableID);
            Assert.AreEqual(ec1.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec1.TableID) == null);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[0].TableID == e3.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[1].TableID == e3.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[2].TableID == e3.TableID);
        }

        [TestMethod]
        public void BoundaryTest_JoinComponentsToNewComposite()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec = eventLogic.JoinComponentsToNewComposite("ec", "d", new Account("n", "u", "e", false), e1);

            Assert.AreEqual(e1.TableID, seasonStub.OnlineContext.GetEventComponent(e1.TableID).TableID);
            Assert.AreEqual(ec.TableID, seasonStub.OnlineContext.GetEventComponent(ec.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(e1.TableID).GetLeafs()[0].TableID == e1.TableID);
        }

        [TestMethod]
        public void PolymorphismTest_JoinComponentsToNewComposite()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec1 = eventLogic.JoinComponentsToNewComposite("ec1", "d", new Account("n", "u", "e", false), e1, e2);
            EventComponent e3 = eventLogic.AddEvent("e3", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec2 = eventLogic.JoinComponentsToNewComposite("ec2", "d", new Account("n", "u", "e", false), ec1, e3);

            Assert.AreEqual(e1.TableID, seasonStub.OnlineContext.GetEventComponent(e1.TableID).TableID);
            Assert.AreEqual(e2.TableID, seasonStub.OnlineContext.GetEventComponent(e2.TableID).TableID);
            Assert.AreEqual(ec1.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec1.TableID) == null);
            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[0].TableID == e1.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[1].TableID == e1.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[2].TableID == e1.TableID);
        }

        [TestMethod]
        public void EquivalenceTest_AddComponentsToComposite()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec1 = eventLogic.JoinComponentsToNewComposite("ec1", "d", new Account("n", "u", "e", false), e1, e2);
            EventComponent e3 = eventLogic.AddEvent("e3", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            eventLogic.AddComponentsToComposite(ec1,new EventComponent[] {e3});

            Assert.AreEqual(ec1.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[0].TableID == e3.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[1].TableID == e3.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[2].TableID == e3.TableID);

            EventComponent e4 = eventLogic.AddEvent("e4", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e5 = eventLogic.AddEvent("e5", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec2 = eventLogic.JoinComponentsToNewComposite("ec2", "d", new Account("n", "u", "e", false), e4, e5);
            EventComponent e6 = eventLogic.AddEvent("e6", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec3 = eventLogic.JoinComponentsToNewComposite("ec3", "d", new Account("n", "u", "e", false), e5, e6);
            eventLogic.AddComponentsToComposite(ec2, new EventComponent[] { ec3 });

            Assert.AreEqual(ec2.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[0].TableID == e6.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[1].TableID == e6.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[2].TableID == e6.TableID);

            Assert.AreEqual(3, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs().Length);
        }

        [TestMethod]
        public void BoundaryTest_AddComponentsToComposite()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec1 = eventLogic.JoinComponentsToNewComposite("ec1", "d", new Account("n", "u", "e", false), e1);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            eventLogic.AddComponentsToComposite(ec1, new EventComponent[] { e2 });

            Assert.AreEqual(ec1.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[0].TableID == e2.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[1].TableID == e2.TableID);
        }

        [TestMethod]
        public void PolymorphismTest_AddComponentsToComposite()
        {
            EventComponent e1 = eventLogic.AddEvent("e1", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e2 = eventLogic.AddEvent("e2", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec1 = eventLogic.JoinComponentsToNewComposite("ec1", "d", new Account("n", "u", "e", false), e1, e2);
            EventComponent e3 = eventLogic.AddEvent("e3", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            eventLogic.AddComponentsToComposite(ec1, new EventComponent[] { e3 });

            Assert.AreEqual(ec1.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[0].TableID == e3.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[1].TableID == e3.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs()[2].TableID == e3.TableID);

            EventComponent e4 = eventLogic.AddEvent("e4", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent e5 = eventLogic.AddEvent("e5", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec2 = eventLogic.JoinComponentsToNewComposite("ec2", "d", new Account("n", "u", "e", false), e4, e5);
            EventComponent e6 = eventLogic.AddEvent("e6", DateTime.Parse("11-11-10"), DateTime.Parse("11-11-10"), null);
            EventComponent ec3 = eventLogic.JoinComponentsToNewComposite("ec3", "d", new Account("n", "u", "e", false), e5, e6);
            eventLogic.AddComponentsToComposite(ec2, new EventComponent[] { ec3 });

            Assert.AreEqual(ec2.TableID, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).TableID);

            Assert.AreEqual(true, seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[0].TableID == e6.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[1].TableID == e6.TableID ||
                                  seasonStub.OnlineContext.GetEventComponent(ec2.TableID).GetLeafs()[2].TableID == e6.TableID);

            Assert.AreEqual(3, seasonStub.OnlineContext.GetEventComponent(ec1.TableID).GetLeafs().Length);
        }
    }
}
