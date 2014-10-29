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
        public int TableID { get; set; }

        public EventComponent[] eventComponents = new EventComponent[0];

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
