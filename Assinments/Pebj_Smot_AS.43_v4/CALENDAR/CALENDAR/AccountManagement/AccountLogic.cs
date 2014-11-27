using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CALENDAR.Storage;
using System.Text.RegularExpressions;
using System.Globalization;
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
        public bool TryCreateAccount(string name, string username, string password, string email)
        {
            //Is input parameters valid inputs? "" and null not allowed
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email))
                return false;
            //Validate that we are online and that the username and email doesn't exist amoung allready existing accounts.
            if (!season.OnlineContext.isOnline())
                return false;
            if (season.OnlineContext.GetAccount(username) != null)
                return false;
            if (season.OnlineContext.GetAccount(email, true) != null)
                return false;

            //Is the value of email a valid e-mail format?
            //Regex validation snippet from http://msdn.microsoft.com/en-us/library/01escwtf%28v=vs.110%29.aspx.
            if (!Regex.IsMatch(email,
             @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
                return false;

            //Try creating the account, hitting the catch here could mean a connection issue or that
            //the synchronizing server rejected the AddAccount action. Only methods inside AccountLogic except
            //for TryLogin enforces for the OnlineContext to be in isOnline state.
            IAccount account = new Account(name, username, email, false);
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