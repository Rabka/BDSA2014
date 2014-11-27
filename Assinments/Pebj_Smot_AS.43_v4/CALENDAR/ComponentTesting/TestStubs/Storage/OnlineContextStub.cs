using System;
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
        private bool isOnlineVar = true;

        /// <summary>
        /// Constructor, initializes default content for testing purposes.
        /// </summary>
        public OnlineContextStub()
        {
            //Initialized test content
            AddAccount(new Account("SeaasonStub person", "u", "p", true));
        }

        /// <summary>
        /// This method is supposed to synchronize changes between local and online database (if possible).
        /// </summary>
        /// <returns>DateTime of last synchronization with the server. The database holds a "lastChanged" Date for all rows
        /// allowing the synchronization to get differences between the databases by simply using this date and take all rows with a lastChanged Date after
        /// the DateTime of last synchronization.</returns>
        public DateTime Sync()
        {
            //Do some synchronization.
            _lastSyncDateTime = DateTime.Now;
            return _lastSyncDateTime;
        }

        /// <summary>
        /// Attempts to try and add an account to the database.
        /// </summary>
        /// <param name="newAccount">Account to add</param>
        public void AddAccount(IAccount newAccount)
        {
            if (accounts.Select(x => x).Any(x => x.Username == newAccount.Username))
                throw new Exception();
            newAccount.TableID = tableID++;
            accounts.Add(newAccount);
        }

        /// <summary>
        /// Attempts to try and remove an account to the database.
        /// </summary>
        /// <param name="newAccount">Account to remove</param>
        public void RemoveAccount(IAccount account)
        {
            accounts.Remove(accounts.Select(x => x).First(x => x.TableID == account.TableID));
        }

        /// <summary>
        /// Attempts to try and update an account from the database.
        /// </summary>
        /// <param name="newAccount">Account to update</param>
        public void UpdateAccount(IAccount account)
        {

        }

        /// <summary>
        /// Gets an account from the database based on an index. If you are a moderator then you will be allowed
        /// to get list accounts without fetching all using this method.
     /// </summary>
     /// <param name="itemIndex">Index of the list of accounts.</param>
     /// <returns>Account</returns>
        public IAccount GetAccount(int itemIndex)
        {
            return accounts[itemIndex];
        }

        /// <summary>
        /// Gets an account based on a given email.
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="inputIsEmail">always set this to true</param>
        /// <returns>Account</returns>
        public IAccount GetAccount(string email, bool inputIsEmail)
        {
            if (inputIsEmail)
                return accounts.Select(x => x).FirstOrDefault(x => x.Email == email);
            throw new FormatException();
        }

        /// <summary>
        /// Gets an account based on a given username.
        /// </summary>
        /// <param name="username">Úsername</param>
        /// <returns>Account</returns>
        public IAccount GetAccount(string username)
        {
            return accounts.Select(x => x).FirstOrDefault(x => x.Username == username);
        }

        /// <summary>
        /// When working with GetAccount(int itemIndex), this method returns the boundary of possible itemIndexes.
        /// </summary>
        /// <returns>int</returns>
        public int GetAccountsCount()
        {
            return accounts.Count;
        }

        /// <summary>
        /// Updates a given EventComponent.
        /// </summary>
        /// <param name="event">EventComponent to update</param>
        public void UpdateEvent(EventComponent @event)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an EventComponent
        /// </summary>
        /// <param name="newEvent">EventComponent</param>
        public void AddEvent(EventComponent newEvent)
        {
            newEvent.TableID = tableID++;
            events.Add(newEvent);
        }

        /// <summary>
        /// Removes an EventComponent
        /// </summary>
        /// <param name="event">EventComponent</param>
        public void RemoveEvent(EventComponent @event)
        {
            events.Remove(events.Select(x => x).First(x => x.TableID == @event.TableID));
        }

        /// <summary>
        /// Gets an EventComponent based on an index. This allows you to iterately fetch EventComponents.
        /// </summary>
        /// <param name="itemIndex">index</param>
        /// <returns>EventComponent</returns>
        public EventComponent GetEventComponent(int itemIndex)
        {
            return events[itemIndex];
        }

        /// <summary>
        /// When working with GetEventComponent(int itemIndex), this method returns the boundary of possible itemIndexes.
        /// </summary>
        /// <returns>int</returns>
        public int GetEventsCount()
        {
            return events.Count;
        }

        /// <summary>
        /// Sets the last time system synchronized. This is more
        /// supposed to be used internally in this class and helps to judge when
        /// a synchronization should be scheduled.
        /// </summary>
        /// <param name="dt">Time of last synchronization</param>
        public void SetLastSync(DateTime dt)
        {
            _lastSyncDateTime = dt;
        }

        /// <summary>
        /// This methods judges if we are online or offline and switches between Online and Offline.
        /// </summary>
        public void checkOnlineStatus()
        {
        }

        /// <summary>
        /// Forceable changes use to the Online or Offline implementation.
        /// This doesn't garantee that the system will stay there since checkOnlineStatus() is
        /// supposed to automaticly switch between them.
        /// </summary>
        /// <param name="isOnline"></param>
        public void SetOfflineOnlineInterface(bool isOnline)
        {
            isOnlineVar = isOnline;
        }
        
        /// <summary>
        /// Is the OnlineContext in the Online state?
        /// </summary>
        /// <returns>boolean</returns>
        public bool isOnline()
        {
            return isOnlineVar;
        }
        /// <summary>
        /// Returns an array of EventComponent between two given dates.
        /// This makes sense to use when we look at a given datetime period in the calendar.
        /// </summary>
        /// <param name="from">DateTime</param>
        /// <param name="to">DateTime</param>
        /// <returns>EventComponent[]</returns>
        public EventComponent[] GetEventComponents(DateTime @from, DateTime to)
        {
            return events.Select(x => x).Where(x => x.DateFrom >= from && x.DateTo <= to).ToArray();
        }

    }
}
