using System;
using System.Collections.Generic;
using System.Text;

namespace Res2019.UserManager
{
    public class UserStatus : IUserStatus
    {
        private static bool IsLoggedIn;// { get; set; }
        private static string User;// { get; set; }

        // zwróć status
        public bool ReturnStatus()
        {
            return IsLoggedIn;
        }
        // zwróć usera
        public string ReturnUser()
        {
            return User;
        }
        // ustaw czy zalogowany czy nie
        public void SetStatus(bool isLogged, string userName)
        {
            if (isLogged)
            {
                IsLoggedIn = true;
                User = userName;
            }
            else
            {
                IsLoggedIn = false;
                User = null;
            }
        }
    }
}
