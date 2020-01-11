using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.MySql
{
    public class MySqlDatabaseSettings : IMySqlDatabaseSettings
    {
        public string MySqlServerName { get; set; } = "";
        public string MySqlUserName { get; set; } = "";
        public string MySqlUserPassword { get; set; } = "";
        public string MySqlDatabaseName { get; set; } = "";
        public string MySqlReservationTableName { get; set; } = "";

        public string MySqlConnectionStringBuild()
        {
            return MySqlServerName + ";" + MySqlUserName + ";" + MySqlUserPassword + ";" + MySqlDatabaseName;
        }
    }
}
