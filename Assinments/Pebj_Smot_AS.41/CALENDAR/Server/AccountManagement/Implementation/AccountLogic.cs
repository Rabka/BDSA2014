using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Database;
namespace Server.AccountManagement
{
    public static class AccountLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns>Succeded boolean</returns>
        public static bool TryCreateAccount(string username, string password, string email)
        {
            //Do some work with the database of accounts.
            return true;
        }
        /// <summary>
        /// Attempts a login and will return a seasonID if succeed.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>SeasonID string</returns>
        public static string TryLogin(string username, string password)
        {
            //Do some work with the database of accounts.
            return "";
        }
        /// <summary>
        /// Removes a specified account.
        /// </summary>
        /// <param name="account"></param>
        public static void removeAccount(Entities.Implementation.Account account)
        {
            //Remove an account.
        }
        /// <summary>
        /// Gets an account based on a given username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public static Entities.Implementation.Account getAccountByUsername(string username)
        {
            //Return an account.
            return null;
        }
        /// <summary>
        /// Gets an account based on a given id.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public static Entities.Implementation.Account getAccountByID(string id)
        {
            //Return an account.
            return null;
        }
    }
}