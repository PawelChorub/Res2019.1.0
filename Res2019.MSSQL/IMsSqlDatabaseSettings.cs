namespace Res2019.MSSQL
{
    public interface IMsSqlDatabaseSettings
    {
        string MsSqlConnectionStringBuild();
        string UseReservationTableName();
        string UseUsersTable();

    }
}