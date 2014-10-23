using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.NotificationManagement.Interfaces
{
    public interface WebserviceTaskI
    {
        /// <summary>
        /// Following method will be called regurally from the keepalive webservice.
        /// </summary>
        void update();
    }
}
