﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CALENDAR.EventManagement
{
    public static class EventLogic
    {
        /// <summary>
        /// Adds a new event to the database
        /// </summary>
        /// <param name="description"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="notifications"></param>
        /// <returns>the event</returns>
        public static Entities.Implementation.Event addEvent(string description, DateTime dateFrom, DateTime dateTo, Entities.Implementation.Notification[] notifications)
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
        public static Entities.Implementation.Event getEventByID(string name)
        {
            return null;
        }
        /// <summary>
        /// Gets the list of all events from and to a specified date.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Event</returns>
        public static Entities.Implementation.Event[] getEvents(DateTime from, DateTime to)
        {
            return null;
        }
        /// <summary>
        /// Removes an existing event from the database
        /// </summary>
        /// <param name="anEvent"></param>
        public static void removeEvent(Entities.Implementation.Event anEvent)
        {

        }
        /// <summary>
        /// updates a given event in the database
        /// </summary>
        /// <returns>true if success</returns>
        public static bool updateEvent(Entities.Implementation.Event anEvent)
        {
            return true;
        }
    }
}