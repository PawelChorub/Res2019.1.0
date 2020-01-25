using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.MSSQL
{
    public class MsSqlDataAccess : IMsSqlDataAccess
    {
        private static IMsSqlDatabaseSettings connectionString;
        
        public MsSqlDataAccess()
        {
            connectionString = MsSqlManager.CreateMsSqlDatabaseSettings();
        }

        private static SqlConnection sqlConnection_New = new SqlConnection(MsSqlDatabaseSettings.MsSqlConnectionStringBuildStatic());
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
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.Message);
            }
        }

    }
}
