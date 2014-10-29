using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CALENDAR.GoogleCalendarAdapter;
using CALENDAR.Synchronization;
namespace CALENDAR.EventManagement
{
    class EventLogic
    {
        /// <summary>
        /// Adds a new event to the database
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="notifications"></param>
        /// <returns>the event</returns>
        public EventLeaf AddEvent(Season season,string description, DateTime dateFrom, DateTime dateTo, Notification[] notifications)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets an event with a specified ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public EventComponent GetEventById(Season season, string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the list of all events from and to a specified date.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public EventComponent[] GetEvents(Season season, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Removes an existing event from the database
        /// </summary>
        /// <param name="anEvent"></param>
        public void RemoveEvent(Season season, EventComponent anEvent)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// updates a given event in the database
        /// </summary>
        public void UpdateEvent(Season season, EventComponent anEvent)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Joins multiple components together to a composite.
        /// </summary>
        /// <returns>EventsComposite</returns>
        public EventsComposite JoinComponentsToNewComposite(Season season, params EventComponent[] components)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add components to a given composite.
        /// </summary>
        public void AddComponentsToComposite(Season season, EventsComposite composite, EventComponent[] components)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets a link for the user to visit for adding the component to his calendar.
        /// </summary>
        /// <returns>true if you are the owner of the event.</returns>
        public string GetSharedEventLink(Season season, EventComponent component)
        {
            throw new NotImplementedException();
        }
    }
}