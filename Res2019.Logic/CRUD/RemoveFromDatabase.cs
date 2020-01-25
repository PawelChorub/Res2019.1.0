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
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        public void DeleteDate(string date_id)
        {
            if (!string.IsNullOrWhiteSpace(date_id))
            {
                query = string.Format("DELETE FROM date WHERE date_id = '{0}'", date_id);
                msSqlDataAccess.SaveData(query);
            }
            else
            {
                MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
            }

        }

        public void DeleteAppointment(string appointment_id)
        {
            if (!string.IsNullOrWhiteSpace(appointment_id))
            {
                query = string.Format("DELETE FROM appointment WHERE appointment_id = '{0}'", appointment_id);
                msSqlDataAccess.SaveData(query);
            }
            else
            {
                MessageBox.Show("Musisz podać godzinę wizyty, którą chcesz usunąć!");
            }
        }
    }
}
