using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.NotificationManagement.Interfaces;
namespace Server.NotificationManagement
{
    public class NotificationTask : WebserviceTaskI, NotificationTaskI
    {
        /// <summary>
        /// Following method will be called regurally from the keepalive webservice.
        /// </summary>
        public void update()
        {

        }
        /// <summary>
        /// Queries the database for upcomming events thus Notification whose dateForNotification has been reached.
        /// </summary>
        /// <returns></returns>
        public Entities.Implementation.Notification[]  getUpcommingNotifications()
        {
            return new Entities.Implementation.Notification[0];
        }
    }
}