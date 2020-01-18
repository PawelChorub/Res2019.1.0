using Res2019.Logic;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019
{
    public class RemoveFromDatabase : IRemoveFromDatabase
    {
        private static IMsSqlDatabaseSettings connectionString = DatabaseManager.CreateMsSqlDatabaseSettings();

        private static SqlConnection sqlConnection_New = new SqlConnection(connectionString.MsSqlConnectionStringBuild_New());
        private static SqlCommand sqlCommand;
        private string sqlQuery = "";

        public void DeleteDateFromDatabase_NEW(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("DELETE FROM date WHERE date_id = '{0}'", id);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                sqlCommand.ExecuteNonQuery();
                sqlConnection_New.Close();
            }
            else
            {
                MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
            }
        }

        public void DeleteAppointmentFromDatabase_NEW(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("DELETE FROM appointment WHERE appointment_id = '{0}'", id);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                sqlCommand.ExecuteNonQuery();
                sqlConnection_New.Close();
            }
            else
            {
                MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
            }
        }
    }
}
