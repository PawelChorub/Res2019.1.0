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

        private static SqlConnection sqlConnection = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlConnection sqlConnection_New = new SqlConnection(connectionString.MsSqlConnectionStringBuild_New());
        private static SqlCommand sqlCommand;
        private string sqlQuery = "";

        private readonly static string table = connectionString.UseReservationTableName();

        public void SaveToSql(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            try
            {
                string isOccupied = "true";
                sqlConnection.Open();
                sqlQuery = string.Format("INSERT INTO {9} (appointmentDate, appointmentTime, appointmentLength," +
                    "appointmentDuration, customerForename, customerSurname, customerTelephoneNumber, serviceName, isOccupied)" +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                     appointment.AppointmentDate,
                     appointment.AppointmentTime,
                     appointment.AppointmentLength,
                     appointment.AppointmentDuration,
                     customer.CustomerForename,
                     customer.CustomerSurname,
                     customer.CustomerTelephoneNumber,
                     service.ServiceName,
                     isOccupied,
                     table);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                OnSaveToDatabaseEventLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.ToString());
            }
        }
        public void SaveNewDateToSql(IDate date)
        {
            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("INSERT INTO date (date, time, length, duration) VALUES ('{0}','{1}','{2}', '{3}')",
                     date.DateDate,
                     date.DateTime,
                     date.DateLength,
                     date.DateDuration);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SaveNewCustomerToSql(ICustomer customer)
        {
            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("INSERT INTO customer (customerForename, customerSurname, customerTelephoneNumber) VALUES ('{0}','{1}','{2}')",
                     customer.CustomerForename,
                     customer.CustomerSurname,
                     customer.CustomerTelephoneNumber);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public void SaveToSql_NEW(IAppointment appointment, ICustomer customer, IMyServices service)
        public void SaveToSql_New(string date_id, string customer_id, string service_id)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd podczas zapisu do bazy, szczegóły: " + ex.ToString());
            }
        }

    }
}
