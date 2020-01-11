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

        private static SqlConnection sqlConnection = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlCommand sqlCommand;
        private string sqlQuery = "";
        private readonly static string table = connectionString.UseReservationTableName();


        public void RemoveAppointmentFromDatabase(string dateOfAppointment, string timeOfAppointment)
        {
            if (!string.IsNullOrWhiteSpace(dateOfAppointment) && !string.IsNullOrWhiteSpace(timeOfAppointment))
            {
                sqlConnection.Open();
                sqlQuery = string.Format("DELETE FROM {2} WHERE appointmentDate = '{0}' AND appointmentTime = '{1}'", dateOfAppointment, timeOfAppointment, table);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
            }
        }
    }
}
