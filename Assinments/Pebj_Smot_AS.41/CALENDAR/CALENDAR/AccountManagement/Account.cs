using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.AccountManagement
{
    public class Account : IAccount
    {
        /// <summary>
        /// Acount constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public Account(string name, string username, string password, string email, bool isModerator)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
            IsModerator = isModerator;
        }
        public readonly bool IsModerator;
        public string TableID { get; set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
    }
}
