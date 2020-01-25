using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.MSSQL
{
    public class MsSqlDatabaseSettings : IMsSqlDatabaseSettings
    {
        public string MsSqlServerName { get; set; } = "Server=.\\SQLEXPR";
        public string MsSqlUserName { get; set; } = "User=sa";
        public string MsSqlUserPassword { get; set; } = "Password=12trzy";
        public string MsSqlDatabaseName { get; set; } = "Database=ReservationSystemNew";
        public string MsSqlUsersTableName { get; set; } = "UsersTable";

        public static string MsSqlServerNameStatic { get; set; } = "Server=.\\SQLEXPR";
        public static string MsSqlUserNameStatic { get; set; } = "User=sa";
        public static string MsSqlUserPasswordStatic { get; set; } = "Password=12trzy";
        public static string MsSqlDatabaseNameStatic { get; set; } = "Database=ReservationSystemNew";
        public static string MsSqlUsersTableNameStatic { get; set; } = "UsersTable";

        public string MsSqlConnectionStringBuild()
        {
            return MsSqlServerName + ";" + MsSqlUserName + ";" + MsSqlUserPassword + ";" + MsSqlDatabaseName;
        }
        public static string MsSqlConnectionStringBuildStatic()
        {
            return MsSqlServerNameStatic + ";" + MsSqlUserNameStatic + ";" + MsSqlUserPasswordStatic + ";" + MsSqlDatabaseNameStatic;
        }
        public string UseUsersTable()
        {
            return MsSqlUsersTableName;
        }

        private static SqlConnection sqlConnection_New = new SqlConnection(MsSqlConnectionStringBuildStatic());
        private static SqlCommand sqlCommand;

        public void SaveData(string sqlQuery)
        {
            try
            {
                sqlConnection_New.Open();
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                sqlCommand.ExecuteNonQuery();
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.ToString());
            }

        }
    }
}
