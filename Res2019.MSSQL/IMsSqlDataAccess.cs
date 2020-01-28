using System.Collections.Generic;

namespace Res2019.MSSQL
{
    public interface IMsSqlDataAccess
    {
        void SaveData(string sqlQuery);
        //List<string> GetData(string sqlQuery, string[] column);
        List<string> GetDataList(string sqlQuery, object model);
        List<string> GetSingleColumnDataList(string sqlQuery, string modelProperty);
        List<string> GetSingleRowDataList(string sqlQuery, string[] column);


    }
}