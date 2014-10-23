using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.EventManagement;
using CALENDAR.AccountManagement;
using CALENDAR.Synchronization;
using CALENDAR.GoogleCalendarAdapter;
using CALENDAR.Commands;
namespace CALENDAR.Storage
{
    class Storage
    {
        public List<IChangeCommand> changeCommands;
        public OnlineContext onlineContext;
        //CHANGES
        public EventLogic eventLogic;
        public AccountLogic accountLogic;
        public Storage()
        {
            onlineContext = new OnlineContext();
            eventLogic = new EventLogic(this);
            accountLogic = new AccountLogic(this);
            changeCommands = new List<IChangeCommand>();
        }
    }
}
