using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CALENDAR.Storage;
using System.Windows.Forms;
namespace CALENDAR.EventManagement
{
    class EventsComposite : EventComponent
    {
        public string TableID { get; set; } 

        private EventComponent[] _eventComponents;

        public EventsComposite(EventComponent[] eventComponents)
        {
            _eventComponents = eventComponents;
        }
        public void Add(EventLogic eventLogic)
        {
            throw new NotImplementedException();
        }
        public void Update(EventLogic eventLogic)
        {
            throw new NotImplementedException();
        }
        public void Delete(EventLogic eventLogic)
        {
            throw new NotImplementedException();
        }
        public void Draw()
        {

        }
    }
}
