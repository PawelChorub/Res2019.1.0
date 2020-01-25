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

        private static SqlConnection sqlConnection = new SqlConnection(MsSqlDatabaseSettings.MsSqlConnectionStringBuildStatic());
        private static SqlCommand sqlCommand;

        public void SaveData(string sqlQuery)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.Message);
            }
        }
    }
}
