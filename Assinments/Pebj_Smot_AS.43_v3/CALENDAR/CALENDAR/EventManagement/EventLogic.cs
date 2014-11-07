 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using CALENDAR.AccountManagement;
 using CALENDAR.GoogleCalendarAdapter;
using CALENDAR.Storage;
namespace CALENDAR.EventManagement
{
    public class EventLogic
    {
        private ISeason season;

        /// <summary>
        /// The class construktor
        /// </summary>
        /// <param name="season">The season to use in all of the methods</param>
        public EventLogic(ISeason season)
        {
            this.season = season;
        }

        /// <summary>
        /// Adds a new event to the database
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="notifications"></param>
        /// <returns>the event</returns>
        public EventComponent AddEvent(string description, DateTime dateFrom, DateTime dateTo, INotification[] notifications)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets an event with a specified ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public EventComponent GetEventById(string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the list of all events from and to a specified date.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public EventComponent[] GetEvents(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Removes an existing event from the database
        /// </summary>
        /// <param name="anEvent"></param>
        public void RemoveEvent(EventComponent anEvent)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// updates a given event in the database
        /// </summary>
        public void UpdateEvent(EventComponent anEvent)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Joins multiple components together to a composite.
        /// </summary>
        /// <returns>EventsComposite</returns>
        public EventComposite JoinComponentsToNewComposite(string title, string description, IAccount ownedByAccount, params EventComponent[] components)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add components to a given composite.
        /// </summary>
        public void AddComponentsToComposite(EventComponent composite, EventComponent[] components)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets a link for the user to visit for adding the component to his calendar.
        /// </summary>
        /// <returns>true if you are the owner of the event.</returns>
        public string GetSharedEventLink(EventComponent component)
        {
            throw new NotImplementedException();
        }
    }
}