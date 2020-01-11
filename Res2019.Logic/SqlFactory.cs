using Ninject.Modules;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic
{
    public class SqlFactory : NinjectModule
    {
        public override void Load()
        {
            Bind<IMsSqlDatabaseSettings>().To<MsSqlDatabaseSettings>().WhenInjectedInto();
        }
    }
}
