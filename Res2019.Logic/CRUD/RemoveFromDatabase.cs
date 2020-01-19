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

        private static SqlConnection sqlConnection_New = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlCommand sqlCommand;
        private string sqlQuery = "";

        public void DeleteDate(string date_id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(date_id))
                {
                    sqlConnection_New.Open();
                    sqlQuery = string.Format("DELETE FROM date WHERE date_id = '{0}'", date_id);
                    sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection_New.Close();
                }
                else
                {
                    MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteAppointment(string appointment_id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(appointment_id))
                {
                    sqlConnection_New.Open();
                    sqlQuery = string.Format("DELETE FROM appointment WHERE appointment_id = '{0}'", appointment_id);
                    sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection_New.Close();
                }
                else
                {
                    MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
