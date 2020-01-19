using Res2019.Logic;
using Res2019.Logic.Models;
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
    public class SaveToDatabase : ISaveToDatabase
    {
        public delegate void SaveToDatabaseHandler(object source, EventArgs e);

        public event SaveToDatabaseHandler SaveToDatabaseEventLog;

        protected virtual void OnSaveToDatabaseEventLog()
        {
            SaveToDatabaseEventLog?.Invoke(this, EventArgs.Empty);
        }
      
        private static IMsSqlDatabaseSettings connectionString = DatabaseManager.CreateMsSqlDatabaseSettings();

        private static SqlConnection sqlConnection_New = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlCommand sqlCommand;
        private string sqlQuery = "";

        public void SaveDate(IDate date)
        {
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("INSERT INTO date (day, time, length, duration) VALUES ('{0}','{1}','{2}', '{3}')",
                     date.DateDay,
                     date.DateTime,
                     date.DateLength,
                     date.DateDuration);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                sqlCommand.ExecuteNonQuery();
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.ToString());
            }
        }
        public void SaveCustomer(ICustomer customer)
        {
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("INSERT INTO customer (forename, surname, telephoneNumber) VALUES ('{0}','{1}','{2}')",
                     customer.CustomerForename,
                     customer.CustomerSurname,
                     customer.CustomerTelephoneNumber);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                sqlCommand.ExecuteNonQuery();
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.ToString());
            }
        }
        public void SaveAppointment(string date_id, string customer_id, string service_id)
        {
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("INSERT INTO appointment" +
                    " (customer_id, service_id, date_id)" +
                    "VALUES ('{0}','{1}','{2}')",
                     customer_id, service_id, date_id);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                sqlCommand.ExecuteNonQuery();
                sqlConnection_New.Close();

                OnSaveToDatabaseEventLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.ToString());
            }
        }

    }
}
