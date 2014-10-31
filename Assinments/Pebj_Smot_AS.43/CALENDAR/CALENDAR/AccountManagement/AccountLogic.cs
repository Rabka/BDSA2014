using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CALENDAR.Synchronization;

namespace CALENDAR.AccountManagement
{
    public class AccountLogic
    {
        private ISeason season;

        /// <summary>
        /// The class construktor
        /// </summary>
        /// <param name="season">The season to use in all of the methods</param>
        public AccountLogic(ISeason season)
        {
            this.season = season;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// Attempts a login and will return a seasonID if succeed.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>return true if success</returns>
        public bool TryLogin(string username, string password)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Removes a specified account.
        /// </summary>
        /// <param name="account"></param>
        /// <returns>return true if success</returns>
        public bool TryRemoveAccount(Account account)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a list of accounts. Requires account type level of moderator.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public Account[] TryListAccounts(int from, int maxAmount)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the number of acccounts.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public int TryGetNumberOfAccounts()
        {
            throw new NotImplementedException();
        }
    }
}