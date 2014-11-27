using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CALENDAR.Storage;

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
        public bool TryCreateAccount(string name,string username, string password, string email)
        {
            //Is input parameters valid inputs? "" and null not allowed
            if (name == null || username == null || password == null || email == null)
                return false;
            if (name == "" || username == "" || password == "" || email == "")
                return false;
            //Validate that we are online and that the username and email doesn't exist amoung allready existing accounts.
            if (!season.OnlineContext.isOnline())
                return false;
            if (season.OnlineContext.GetAccount(username) != null)
                return false;
            if (season.OnlineContext.GetAccount(email,true) != null)
                return false;
            //Try creating the account, hitting the catch here could mean a connection issue or that
            //the synchronizing server rejected the AddAccount action. Only methods inside AccountLogic except
            //for TryLogin enforces for the OnlineContext to be in isOnline state.
            IAccount account = new Account(name,username,email,false);
            try
            {
                season.OnlineContext.AddAccount(account);
            }
            catch
            {
                return false;
            }
            return true;
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
        public bool TryRemoveAccount(IAccount account)
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