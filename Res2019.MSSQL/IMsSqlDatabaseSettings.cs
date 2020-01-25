namespace Res2019.MSSQL
{
    public interface IMsSqlDatabaseSettings
    {
        string UseUsersTable();
        string MsSqlConnectionStringBuild();

        void SaveData(string sqlQuery);

    }
}