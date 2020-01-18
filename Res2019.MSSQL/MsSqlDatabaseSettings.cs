using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.MSSQL
{
    public class MsSqlDatabaseSettings : IMsSqlDatabaseSettings
    {
        public string MsSqlServerName { get; set; } = "Server=.\\SQLEXPR";
        public string MsSqlUserName { get; set; } = "User=sa";
        public string MsSqlUserPassword { get; set; } = "Password=12trzy";
        public string MsSqlDatabaseName_New { get; set; } = "Database=ReservationSystemNew";
        public string MsSqlUsersTableName { get; set; } = "UsersTable";

        public string MsSqlConnectionStringBuild_New()
        {
            return MsSqlServerName + ";" + MsSqlUserName + ";" + MsSqlUserPassword + ";" + MsSqlDatabaseName_New;
        }
        public string UseUsersTable()
        {
            return MsSqlUsersTableName;
        }
    }
}
