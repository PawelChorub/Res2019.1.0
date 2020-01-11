using Ninject.Modules;
using Res2019.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.UsersManager
{
    public class UserManagerContainerConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountManager>().To<AccountManager>();
            Bind<IUserStatus>().To<UserStatus>();
            Bind<ISCryptHashing>().To<SCryptHashing>();
            
        }
    }
}
