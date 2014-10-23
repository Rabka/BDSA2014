using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
namespace Server.NotificationManagement
{
    public static class MailUtils
    {
        /// <summary>
        /// Sends a given mail message
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns>succeeded boolean</returns>
        public static bool sendMail(string email, MailMessage message)
        {
            return true;
        }
    }
}