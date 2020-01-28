using Ninject;
using Res2019.Logic;
using Res2019.Logic.Models;
using Res2019.Logic.Processors;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Res2019
{
    public class ReadFromDatabase : IReadFromDatabase
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";

        public List<string> GetListOfDate_id(string day)
        {
            IDate date = kernel.Get<IDate>();

            var modelProperty = date.GetType().GetProperty("Date_Id").Name;
            query = string.Format("SELECT * FROM date WHERE day = '{0}'", day);
            var receivedData = msSqlDataAccess.GetSingleColumnDataList(query, modelProperty);
            return receivedData;
        }

        public List<IAppointmentDetails> GetListOfAppointment(string day)
        {
            List<IAppointmentDetails> appointmentList = new List<IAppointmentDetails>();

            var date_idList = GetListOfDate_id(day);

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

        public IAppointmentDetails BuildAppointmentDetails(string [] idColumnSet)
        {
            IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();
            if (idColumnSet.Length > 0)
            {
                customer = GetCustomer(idColumnSet[1]);
                service = GetService(idColumnSet[2]);
                date = GetDate(idColumnSet[3]);

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

        private IAppointmentDetails GetAppointment(string _appointment_id)
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
            IDate date = GetDate(day, time);
            string date_id = date.Date_Id;
            return GetAppointmentDetails(date_id).AppointmentId;
        }

        private IDate GetDate(string date_id)
        {
            IDate date = kernel.Get<IDate>();
            IDateProcessor dateProcessor = kernel.Get<IDateProcessor>();

            query = string.Format("SELECT * FROM date WHERE date_id = '{0}'", date_id);
            var receivedData = msSqlDataAccess.GetDataList(query, date).ToArray();

            date = dateProcessor.CreateDate(receivedData);
            return date;
        }

        public IDate GetDate(string day, string time)
        {
            IDate date = kernel.Get<IDate>();
            IDateProcessor dateProcessor = kernel.Get<IDateProcessor>();

            query = string.Format("SELECT * FROM date WHERE day = '{0}' AND time = '{1}'", day, time);
            var receivedData = msSqlDataAccess.GetDataList(query, date).ToArray();

            date = dateProcessor.CreateDate(receivedData);
            return date;
        }

        private ICustomer GetCustomer(string customer_id)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            ICustomerProcessor customerProcessor = kernel.Get<ICustomerProcessor>();

            query = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'", customer_id);
            var receivedData = msSqlDataAccess.GetDataList(query, customer).ToArray();

            customer = customerProcessor.CreateCustomer(receivedData);
            return customer;
        }

        public ICustomer GetCustomer(ICustomer _customer)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            ICustomerProcessor customerProcessor = kernel.Get<ICustomerProcessor>();

            query = string.Format("SELECT * FROM customer WHERE forename = '{0}' AND surname = '{1}' AND telephone = '{2}'", _customer.Forename, _customer.Surname, _customer.Telephone);
            var receivedData = msSqlDataAccess.GetDataList(query, customer).ToArray();

            customer = customerProcessor.CreateCustomer(receivedData);
            return customer;
        }

        public IMyServices GetService(IMyServices _service)
        {
            IMyServices service = kernel.Get<IMyServices>();
            IMyServicesProcessor myServicesProcessor = kernel.Get<IMyServicesProcessor>();

            query = string.Format("SELECT * FROM service WHERE name = '{0}'", _service.Name);
            var receivedData = msSqlDataAccess.GetDataList(query, service).ToArray();

            service = myServicesProcessor.CreateService(receivedData);
            return service;
        }

        private IMyServices GetService(string service_id)
        {
            IMyServices service = kernel.Get<IMyServices>();
            IMyServicesProcessor myServicesProcessor = kernel.Get<IMyServicesProcessor>();

            query = string.Format("SELECT * FROM service WHERE service_id = '{0}'", service_id);
            var receivedData = msSqlDataAccess.GetDataList(query, service).ToArray();

            service = myServicesProcessor.CreateService(receivedData);
            return service;
        }
    }
}
