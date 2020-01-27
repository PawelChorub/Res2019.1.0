using Res2019.Logic;
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

        protected virtual void OnUpdatedToDatabase(IDate date, ICustomer customer, IMyServices service)
        {
            UpdatedToDatabase?.Invoke(this, new AppointmentEventArgs()
            {
                Date = date,
                Customer = customer,
                Service = service
            });
        }

        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        public void UpdateDate(IDate date, IAppointment appointment)
        {
            query = string.Format("UPDATE date SET day = '{0}'," +
                "time = '{1}', length = '{2}', duration = '{3}' WHERE date_id = '{4}'",
                date.DateDay,
                date.DateTime,
                appointment.AppointmentLength,
                appointment.AppointmentDuration,
                date.Date_Id);
            msSqlDataAccess.SaveData(query);
        }
        public void UpdateAppointment(IDate date, ICustomer customer, IMyServices service, string appointmentToModify_id)
        {
            query = string.Format("UPDATE appointment SET customer_id = '{0}'," +
                "service_id = '{1}', date_id = '{2}' WHERE appointment_id = '{3}'",
                customer.CustomerId,
                service.Service_Id,
                date.Date_Id,
                appointmentToModify_id);
            msSqlDataAccess.SaveData(query);

            OnUpdatedToDatabase(date, customer, service);
        }
    }
}
