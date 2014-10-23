using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CALENDAR.GoogleCalendarAdapter;
namespace CALENDAR.EventManagement
{
    class EventLogic
    {
        Storage.Storage storage;
        public IEventClient eventAdapter;

        public EventLogic(Storage.Storage storage)
        {
            this.storage = storage;
            eventAdapter = new EventAdapter(storage);
        }
        /// <summary>
        /// Adds a new event to the database
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="notifications"></param>
        /// <returns>the event</returns>
        public EventLeaf AddEvent(string description, DateTime dateFrom, DateTime dateTo, Notification[] notifications)
        {
            try
            {
                //Update local database and srerver and create the event. If a problem accur throw exception
                return null; 
            }
            catch
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Gets an event with a specified ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public EventComponent GetEventById(string name)
        {
            return null;
        }
        /// <summary>
        /// Gets the list of all events from and to a specified date.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public EventComponent[] GetEvents(DateTime from, DateTime to)
        {
            return null;
        }
        /// <summary>
        /// Removes an existing event from the database
        /// </summary>
        /// <param name="anEvent"></param>
        public void RemoveEvent(EventComponent anEvent)
        {

        }
        /// <summary>
        /// updates a given event in the database
        /// </summary>
        /// <returns>true if success</returns>
        public bool UpdateEvent(EventComponent anEvent)
        {
            return true;
        }
        /// <summary>
        /// Joins multiple components together to a composite.
        /// </summary>
        /// <returns>true if success</returns>
        public bool JoinComponentsToComposite(params EventComponent[] components)
        {
            return false;
        }
        /// <summary>
        /// Add components to a given composite.
        /// </summary>
        /// <returns>true if success</returns>
        public bool AddComponentsToComposite(EventsComposite composite,params EventComponent[] components)
        {
            return false;
        }
    }
}