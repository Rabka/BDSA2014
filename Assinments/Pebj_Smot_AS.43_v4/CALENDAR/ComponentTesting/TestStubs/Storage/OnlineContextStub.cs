﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.AccountManagement;
using CALENDAR.EventManagement;
using CALENDAR.Commands;
using CALENDAR.Storage;
namespace CALENDAR.Storage
{
    public class OnlineContextStub : IOnlineContext
    {
        int tableID = 0;
        List<IAccount> accounts = new List<IAccount>();
        List<EventComponent> events = new List<EventComponent>();
        DateTime _lastSyncDateTime = DateTime.Now;
        /// <summary>
        /// Synchronizes the local database with that of the server.
        /// </summary>
        /// <returns>DateTime of last synchronization with the server. The database holds a "lastChanged" Date for all rows
        /// allowing the synchronization to get differences between the databases by simply using this date and take all rows with a lastChanged Date after
        /// the DateTime of last synchronization.
        /// </returns>
        public DateTime Sync(IChangeCommand[] commands)
        {
            //Do some synchronization.
            commands.ToList().ForEach(x => x.SetOnlineContext(this));
            _lastSyncDateTime = DateTime.Now;
            return _lastSyncDateTime;
        }

        public DateTime Sync()
        {
            throw new NotImplementedException();
        }

        public void AddAccount(IAccount newAccount)
        {
            if (accounts.Select(x => x).Any(x => x.Username == newAccount.Username))
                throw new Exception();
            newAccount.TableID = tableID++;
            accounts.Add(newAccount);
        }
        public void RemoveAccount(IAccount account)
        {
            accounts.Remove(accounts.Select(x => x).First(x => x.TableID == account.TableID));
        }
        public void UpdateAccount(IAccount account)
        {

        }
        public IAccount GetAccount(int itemIndex)
        {
            return accounts[itemIndex];
        }
        public IAccount GetAccount(string email, bool inputIsEmail)
        {
            if (inputIsEmail)
                return accounts.Select(x => x).Where(x => x.Email == email).ToList().FirstOrDefault();
            throw new FormatException();
        }
        public IAccount GetAccount(string username)
        {
            return accounts.Select(x => x).Where(x => x.Username == username).ToList().FirstOrDefault();
        }
        public int GetAccountsCount()
        {
            return accounts.Count;
        }
        public void UpdateEvent(EventComponent @event)
        {
            throw new NotImplementedException();
        }

        public void AddEvent(EventComponent newEvent)
        {
            newEvent.TableID = tableID++;
            events.Add(newEvent);
        }
        public void RemoveEvent(EventComponent @event)
        {
            events.Remove(events.Select(x => x).First(x => x.TableID == @event.TableID));
        }
        public EventComponent GetEventComponent(int itemIndex)
        {
            return events[itemIndex];
        }
        public int GetEventsCount()
        {
            return events.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void SetLastSync(DateTime dt)
        {
            _lastSyncDateTime = dt;
        }
        public void checkOnlineStatus()
        {
        }

        void IOnlineContext.SetOfflineOnlineInterface(bool isOnline)
        {
            SetOfflineOnlineInterface(isOnline);
        }

        private void SetOfflineOnlineInterface(bool isOnline)
        {
        }

        private bool isOnlineVar = true;

        public bool isOnline()
        {
            return isOnlineVar;
        }

        public EventComponent[] GetEventComponents(DateTime @from, DateTime to)
        {
            throw new NotImplementedException();
        }

        EventComponent[] GetEvents(DateTime from, DateTime to)
        {
            return events.Select(x => x).Where(x => x.DateFrom >= from && x.DateTo <= to).ToArray();
        }

        public void IsOnlineToFalse()
        {
            isOnlineVar = false;
        }
    }
}