using Ninject;
using Res2019.Logic.Events;
using Res2019.Logic.Models;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.Logic.Controller
{
    public class AppointmentController : IAppointmentController
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        IDateController dateController;
        IMyServicesController myServicesController;
        ICustomerController customerController;

        public AppointmentController()
        {
            dateController = kernel.Get<IDateController>();
            myServicesController = kernel.Get<IMyServicesController>();
            customerController = kernel.Get<ICustomerController>();
        }
        public delegate void SaveToDatabaseHandler(object source, EventArgs e);

        public event SaveToDatabaseHandler SaveToDatabaseEventLog;

        protected virtual void OnSaveToDatabaseEventLog()
        {
            SaveToDatabaseEventLog?.Invoke(this, EventArgs.Empty);
        }

        public void SaveAppointment(string date_id, string customer_id, string service_id)
        {
            query = string.Format("INSERT INTO appointment (customer_id, service_id, date_id) VALUES ('{0}','{1}','{2}')",
                 customer_id, service_id, date_id);
            msSqlDataAccess.SaveData(query);

            OnSaveToDatabaseEventLog(); // to przenieść, albo dać if
        }

        public List<IAppointmentDetails> GetListOfAppointment(string day)
        {
            List<IAppointmentDetails> appointmentList = new List<IAppointmentDetails>();

            var date_idList = dateController.GetListOfDate_id(day);

            foreach (var date_id in date_idList)
            {
                if (!string.IsNullOrEmpty(date_id))
                {
                    try
                    {
                        appointmentList.Add(GetAppointmentDetails(date_id));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            return appointmentList;
        }

        public IAppointmentDetails GetAppointment(string day, string time)
        {
            IAppointmentDetails appointment = null;
            string id = GetAppointment_id(day, time);
            if (!string.IsNullOrWhiteSpace(id))
            {
                appointment = kernel.Get<IAppointmentDetails>();
                appointment = GetAppointment(id);
            }
            return appointment;
        }

        private IAppointmentDetails BuildAppointmentDetails(string[] idColumnSet)
        {
            IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();
            if (idColumnSet.Length > 0)
            {
                customer = customerController.GetCustomer(idColumnSet[1]);
                service = myServicesController.GetService(idColumnSet[2]);
                date = dateController.GetDate(idColumnSet[3]);

                appointment.Forename = customer.Forename;
                appointment.Surname = customer.Surname;
                appointment.Telephone = customer.Telephone;
                appointment.AppointmentDay = date.Day;
                appointment.AppointmentTime = date.Time;
                appointment.AppointmentDuration = date.Duration;
                appointment.AppointmentLength = date.Length;
                appointment.AppointmentId = idColumnSet[0];
                appointment.Name = service.Name;
            }
            return appointment;
        }

        public IAppointmentDetails GetAppointment(string _appointment_id)
        {
            query = string.Format("SELECT * FROM appointment WHERE appointment_id = '{0}'", _appointment_id);
            var column = new string[] { "appointment_id", "customer_id", "service_id", "date_id" };
            var receivedData = msSqlDataAccess.GetSingleRowDataList(query, column).ToArray();
            return BuildAppointmentDetails(receivedData);
        }
        public IAppointmentDetails GetAppointmentDetails(string _date_id)
        {
            query = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", _date_id);
            var column = new string[] { "appointment_id", "customer_id", "service_id", "date_id" };
            var receivedData = msSqlDataAccess.GetSingleRowDataList(query, column).ToArray();
            return BuildAppointmentDetails(receivedData);
        }
        public string GetAppointment_id(string day, string time)
        {
            IDate date = dateController.GetDate(day, time);
            string date_id = date.Date_Id;
            return GetAppointmentDetails(date_id).AppointmentId;
        }
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


        public void UpdateAppointment(IDate date, ICustomer customer, IMyServices service, string appointmentToModify_id)
        {
            query = string.Format("UPDATE appointment SET customer_id = '{0}'," +
                "service_id = '{1}', date_id = '{2}' WHERE appointment_id = '{3}'",
                customer.Customer_Id,
                service.Service_Id,
                date.Date_Id,
                appointmentToModify_id);
            msSqlDataAccess.SaveData(query);

            OnUpdatedToDatabase(date, customer, service);
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
