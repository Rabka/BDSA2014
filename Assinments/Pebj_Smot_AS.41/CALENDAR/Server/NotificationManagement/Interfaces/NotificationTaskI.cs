using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Server.NotificationManagement.Interfaces
{
    public interface NotificationTaskI
    {
        Entities.Implementation.Notification[] getUpcommingNotifications();
    }
}
