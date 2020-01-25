using Res2019.MSSQL;
using Res2019.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic
{
    public static class DatabaseManager
    {
        public static IMsSqlDatabaseSettings CreateMsSqlDatabaseSettings_OLD()
        {
            return new MsSqlDatabaseSettings();
        }
        public static IMySqlDatabaseSettings CreateMySqlDatabaseSettings()
        {
            return new MySqlDatabaseSettings();
        }
    }
}
