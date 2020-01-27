using System.Collections.Generic;

namespace Res2019.MSSQL
{
    public interface IMsSqlDataAccess
    {
        void SaveData(string sqlQuery);
        List<string> GetData(string sqlQuery, string[] column);
        List<string> GetData(string sqlQuery, object model);


    }
}