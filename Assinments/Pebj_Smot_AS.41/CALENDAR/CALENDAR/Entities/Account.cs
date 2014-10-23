using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CALENDAR.Entities
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
        public Account(string id, string name, string username, string password, string email)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
    }
}
