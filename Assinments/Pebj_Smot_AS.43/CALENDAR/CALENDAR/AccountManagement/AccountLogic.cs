using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CALENDAR.Synchronization;

namespace CALENDAR.AccountManagement
{
    public class AccountLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <returns>Succeded boolean</returns>
        public bool TryCreateAccount(ISeason season, string username, string password, string email)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Attempts a login and will return a seasonID if succeed.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>return true if success</returns>
        public bool TryLogin(ISeason season, string username, string password)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Removes a specified account.
        /// </summary>
        /// <param name="account"></param>
        /// <returns>return true if success</returns>
        public bool TryRemoveAccount(ISeason season, Account account)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Returns a list of accounts. Requires account type level of moderator.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public Account[] TryListAccounts(ISeason season, int from, int maxAmount)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Gets the number of acccounts.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Account</returns>
        public int TryGetNumberOfAccounts(ISeason season)
        {
            throw new NotImplementedException();
        }
    }
}