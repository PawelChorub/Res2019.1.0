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

        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        public void SaveDate(IDate date)
        {
            query = string.Format("INSERT INTO date (day, time, length, duration) VALUES ('{0}','{1}','{2}', '{3}')",
                 date.DateDay,
                 date.DateTime,
                 date.DateLength,
                 date.DateDuration);

            msSqlDataAccess.SaveData(query);
        }
        public void SaveCustomer(ICustomer customer)
        {
            query = string.Format("INSERT INTO customer (forename, surname, telephoneNumber) VALUES ('{0}','{1}','{2}')",
                  customer.CustomerForename,
                  customer.CustomerSurname,
                  customer.CustomerTelephoneNumber);
            msSqlDataAccess.SaveData(query);
        }
        public void SaveAppointment(string date_id, string customer_id, string service_id)
        {
            query = string.Format("INSERT INTO appointment (customer_id, service_id, date_id) VALUES ('{0}','{1}','{2}')",
                 customer_id, service_id, date_id);
            msSqlDataAccess.SaveData(query);

            OnSaveToDatabaseEventLog(); // to przenieść, albo dać if
        }
    }
}
