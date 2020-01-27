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
        private static IMsSqlDatabaseSettings connectionString = DatabaseManager.CreateMsSqlDatabaseSettings_OLD();

        private static SqlConnection sqlConnection = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlCommand sqlCommand;
        private static SqlDataReader reader;
        private string sqlQuery = "";
        //*****************************
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";


        public List<string> GetListOfDate_id(string day)
        {
            List<string> date_id = new List<string>();

            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM date WHERE day = '{0}'", day);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        date_id.Add(reader["date_id"].ToString());
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return date_id;
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

        private IAppointmentDetails GetAppointment(string appointment_id)
        {
            IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();

            if (!string.IsNullOrEmpty(appointment_id))
            {
                var customer_id = "";
                var date_id = "";
                var service_id = "";

                try
                {
                    sqlConnection.Open();
                    sqlQuery = string.Format("SELECT * FROM appointment WHERE appointment_id = '{0}'", appointment_id);
                    sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customer_id = reader["customer_id"].ToString();
                            service_id = reader["service_id"].ToString();
                            date_id = reader["date_id"].ToString();
                        }
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                SetAppointmentDetails(appointment, out date, out customer, out service, customer_id, date_id, service_id);
            }
            return appointment;
        }

        public string GetAppointment_id(string day, string time)
        {
            IDate date = kernel.Get<IDate>();
            date = GetDate(day, time);
            string date_id = date.Date_Id;
            string appointment_id = "";
            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", date_id);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        appointment_id = reader["appointment_id"].ToString();
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return appointment_id;
        }

        private void SetAppointmentDetails(IAppointmentDetails appointment, out IDate date, out ICustomer customer, out IMyServices service, string customer_id, string date_id, string service_id)
        {
            date = GetDate(date_id);
            customer = GetCustomer(customer_id);
            service = GetService(service_id);

            appointment.Forename = customer.Forename;
            appointment.Surname = customer.Surname;
            appointment.Telephone = customer.Telephone;
            appointment.AppointmentDay = date.DateDay;
            appointment.AppointmentTime = date.DateTime;
            appointment.AppointmentDuration = date.DateDuration;
            appointment.AppointmentLength = date.DateLength;
            appointment.Name = service.Name;
        }

        public IAppointmentDetails GetAppointmentDetails(string _date_id)
        {
            IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();

            var customer_id = "";
            var date_id = "";
            var service_id = "";

            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", _date_id);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customer_id = reader["customer_id"].ToString();
                        service_id = reader["service_id"].ToString();
                        date_id = reader["date_id"].ToString();
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            SetAppointmentDetails(appointment, out date, out customer, out service, customer_id, date_id, service_id);

            return appointment;
        }

        private IDate GetDate(string date_id)
        {
            IDate date = kernel.Get<IDate>();
            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM date WHERE date_id = '{0}'", date_id);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        date.DateDay = reader["day"].ToString();
                        date.DateTime = reader["time"].ToString();
                        date.DateLength = reader["length"].ToString();
                        date.DateDuration = reader["duration"].ToString();
                        date.Date_Id = reader["date_id"].ToString();
                    }
                }
                else
                {
                    date = null;
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return date;
        }

        public IDate GetDate(string day, string time)
        {
            IDate date = kernel.Get<IDate>();
            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM date WHERE day = '{0}' AND time = '{1}'", day, time);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        date.DateDay = reader["day"].ToString();
                        date.DateTime = reader["time"].ToString();
                        date.DateLength = reader["length"].ToString();
                        date.DateDuration = reader["duration"].ToString();
                        date.Date_Id = reader["date_id"].ToString();
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return date;
        }

        private ICustomer GetCustomer(string customer_id)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            ICustomerProcessor customerProcessor = kernel.Get<ICustomerProcessor>();

            query = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'", customer_id);
            var receivedData = msSqlDataAccess.GetData(query, customer).ToArray();

            customer = customerProcessor.CreateCustomer(receivedData);
            return customer;
        }

        public ICustomer GetCustomer(ICustomer _customer)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            ICustomerProcessor customerProcessor = kernel.Get<ICustomerProcessor>();

            query = string.Format("SELECT * FROM customer WHERE forename = '{0}' AND surname = '{1}' AND telephone = '{2}'", _customer.Forename, _customer.Surname, _customer.Telephone);
            var receivedData = msSqlDataAccess.GetData(query, customer).ToArray();

            customer = customerProcessor.CreateCustomer(receivedData);
            return customer;
        }

        public IMyServices GetService(IMyServices _service)
        {
            IMyServices service = kernel.Get<IMyServices>();
            IMyServicesProcessor myServicesProcessor = kernel.Get<IMyServicesProcessor>();

            query = string.Format("SELECT * FROM service WHERE name = '{0}'", _service.Name);
            var receivedData = msSqlDataAccess.GetData(query, service).ToArray();

            service = myServicesProcessor.CreateService(receivedData);
            return service;
        }

        private IMyServices GetService(string service_id)
        {
            IMyServices service = kernel.Get<IMyServices>();
            IMyServicesProcessor myServicesProcessor = kernel.Get<IMyServicesProcessor>();

            query = string.Format("SELECT * FROM service WHERE service_id = '{0}'", service_id);
            var receivedData = msSqlDataAccess.GetData(query, service).ToArray();

            service = myServicesProcessor.CreateService(receivedData);
            return service;
        }
    }
}
