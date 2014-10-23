using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CALENDAR.AccountManagement
{
    class AccountLogic
    {
        //The account currently logged in.
        private Account account;

        Storage.Storage storage;
        public AccountLogic(Storage.Storage storage)
        {
            this.storage = storage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns>Succeded boolean</returns>
        public bool TryCreateAccount(string username, string password, string email)
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
        public string TryLogin(string username, string password)
        {
            //Do some work with the database of accounts.
            return "";
        }
        /// <summary>
        /// Removes a specified account.
        /// </summary>
        /// <param name="account"></param>
        public static void RemoveAccount(Account account)
        {
            //Remove an account.
        }
        /// <summary>
        /// Gets an account based on a given username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public Account GetCurrentAccount()
        {
            //Returns currently used account.
            return account;
        }
        /// <summary>
        /// Returns a list of accounts. Requires account type level of moderator.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public Account[] ListAccounts(int from,int maxAmount)
        {
            //Return an account.
            return null;
        }
    }
}