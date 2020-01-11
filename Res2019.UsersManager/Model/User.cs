using System;
using System.Collections.Generic;
using System.Text;

namespace Res2019.UserManager.Model
{
    public class User : IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        //public bool IsLoggedIn { get; set; }
        //public bool IsRegisteredIn { get; set; }
    }
}
