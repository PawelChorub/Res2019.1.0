using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.MSSQL
{
    public static class MsSqlManager
    {
        public static IMsSqlDatabaseSettings CreateMsSqlDatabaseSettings()
        {
            return new MsSqlDatabaseSettings();
        }
        public static IMsSqlDataAccess CreateMsSqlDataAccess()
        {
            return new MsSqlDataAccess();
        }
    }
}
