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
        public Account(string name, string username,string email, bool isModerator)
        {
            Name = name;
            Username = username;
            Email = email;
            IsModerator = isModerator;
       
        }
        public readonly bool IsModerator;
        public int TableID { get; set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        //Password will only exist in the database. It is not possible to get the password of a user.
    }
}
