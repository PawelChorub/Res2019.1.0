namespace Res2019.MySql
{
    public interface IMySqlDatabaseSettings
    {
        string MySqlDatabaseName { get; set; }
        string MySqlReservationTableName { get; set; }
        string MySqlServerName { get; set; }
        string MySqlUserName { get; set; }
        string MySqlUserPassword { get; set; }

        string MySqlConnectionStringBuild();
    }
}