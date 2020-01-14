﻿using Res2019.Logic;
using Res2019.Logic.Events;
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
    public class UpdateToDatabase : IUpdateToDatabase
    {
        public delegate void UpdatedToDatabaseHandler(object source, AppointmentEventArgs args);

        public event UpdatedToDatabaseHandler UpdatedToDatabase;

        protected virtual void OnUpdatedToDatabase(IAppointmentDetails appointmentDetails)
        {
            UpdatedToDatabase?.Invoke(this, new AppointmentEventArgs() { AppointmentDetails = appointmentDetails});
        }

        private static IMsSqlDatabaseSettings connectionString = DatabaseManager.CreateMsSqlDatabaseSettings();

        private static SqlConnection sqlConnection = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlCommand sqlCommand;
        private string sqlQuery = "";
        private readonly static string table = connectionString.UseReservationTableName();

        public void ModifyToSql(IAppointmentDetails appointmentDetails)
        {
            try
            {
                string isOccupied = "true";
                sqlConnection.Open();
                sqlQuery = string.Format("UPDATE {9} SET appointmentLength = '{2}'," +
                    "appointmentDuration = '{3}', customerForename = '{4}', customerSurname = '{5}'," +
                    "customerTelephoneNumber = '{6}', serviceName = '{7}', isOccupied = '{8}' WHERE appointmentDate = '{0}' AND appointmentTime = '{1}'",
                    appointmentDetails.AppointmentDate,
                    appointmentDetails.AppointmentTime,
                    appointmentDetails.AppointmentLength,
                    appointmentDetails.AppointmentDuration,
                    appointmentDetails.CustomerForename,
                    appointmentDetails.CustomerSurname,
                    appointmentDetails.CustomerTelephoneNumber,
                    appointmentDetails.ServiceName,
                    isOccupied,
                    table
                    );
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                OnUpdatedToDatabase(appointmentDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieudana modyfikacja wizyty podczas zapisu do bazy. Szczegóły: " + ex.ToString());
            }
        }
    }
}