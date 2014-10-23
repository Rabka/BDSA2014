using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Entities.Implementation
{
    public class Account : Entities.Interfaces.IAccount
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
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
        }
        string id = "";
        string name = "";
        string username = "";
        string password = "";
        string email = "";
        /// <summary>
        /// gets the id of the account
        /// </summary>
        /// <returns>string</returns>
        public string getID()
        {
            return id;
        }
        /// <summary>
        /// gets the name of the account
        /// </summary>
        /// <returns>string</returns>
        public string getName()
        {
            return name;
        }
        /// <summary>
        /// gets the username of the account
        /// </summary>
        /// <returns>string</returns>
        public string getUsername()
        {
            return username;
        }
        /// <summary>
        /// gets the password of the account
        /// </summary>
        /// <returns>string</returns>
        public string getPassword()
        {
            return password;
        }
        /// <summary>
        /// gets the email of the account
        /// </summary>
        /// <returns>string</returns>
        public string getEmail()
        {
            return email;
        }
    }
}
