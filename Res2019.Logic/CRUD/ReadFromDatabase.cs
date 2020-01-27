﻿using Ninject;
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
            IDate date = kernel.Get<IDate>();

            var modelProperty = date.GetType().GetProperty("Date_Id").Name;
            query = string.Format("SELECT * FROM date WHERE day = '{0}'", day);
            var receivedData = msSqlDataAccess.GetSingleColumnDataList(query, modelProperty);

            return receivedData;

            //---------------
            //List<string> date_id = new List<string>();

            //try
            //{
            //    sqlConnection.Open();
            //    sqlQuery = string.Format("SELECT * FROM date WHERE day = '{0}'", day);
            //    sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //    reader = sqlCommand.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            date_id.Add(reader["date_id"].ToString());
            //        }
            //    }
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //return date_id;
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

        //public List<string> GetDetails(string search_id)
        //{
        //    sqlQuery = string.Format("SELECT * FROM appointment WHERE appointment_id = '{0}'", search_id);
        //    var col = new string[] { "appointment_id", "customer_id", "service_id", "date_id" };
        //    var x = msSqlDataAccess.GetSingleRowDataList(sqlQuery, col);
        //    //BuildAppointmentDetails(x);
        //    return x;
        //}

        public IAppointmentDetails BuildAppointmentDetails(string [] ids)
        {
            IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();
            if (ids.Length > 0)
            {
                date = GetDate(ids[3]);
                customer = GetCustomer(ids[1]);
                service = GetService(ids[2]);


                appointment.Forename = customer.Forename;
                appointment.Surname = customer.Surname;
                appointment.Telephone = customer.Telephone;
                appointment.AppointmentDay = date.Day;
                appointment.AppointmentTime = date.Time;
                appointment.AppointmentDuration = date.Duration;
                appointment.AppointmentLength = date.Length;
                appointment.AppointmentId = ids[0];
                appointment.Name = service.Name;

            }
            return appointment;

        }

        private IAppointmentDetails GetAppointment(string _appointment_id)
        {
            sqlQuery = string.Format("SELECT * FROM appointment WHERE appointment_id = '{0}'", _appointment_id);
            var col = new string[] { "appointment_id", "customer_id", "service_id", "date_id" };
            var x = msSqlDataAccess.GetSingleRowDataList(sqlQuery, col).ToArray();
            
            return BuildAppointmentDetails(x);


            //IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            //IDate date = kernel.Get<IDate>();
            //ICustomer customer = kernel.Get<ICustomer>();
            //IMyServices service = kernel.Get<IMyServices>();

            //if (!string.IsNullOrEmpty(_appointment_id))
            //{
            //    var customer_id = "";
            //    var date_id = "";
            //    var service_id = "";
            //    var appointment_id = "";

            //    try
            //    {
            //        sqlConnection.Open();
            //        sqlQuery = string.Format("SELECT * FROM appointment WHERE appointment_id = '{0}'", _appointment_id);
            //        sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //        reader = sqlCommand.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                // odczyt wszystkich kolumn w accesssie
            //                customer_id = reader["customer_id"].ToString();
            //                service_id = reader["service_id"].ToString();
            //                date_id = reader["date_id"].ToString();
            //                appointment_id = reader["appointment_id"].ToString();
            //            }
            //        }
            //        sqlConnection.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //    SetAppointmentDetails(appointment, out date, out customer, out service, customer_id, date_id, service_id);
            //}
            //return appointment;
        }
        public IAppointmentDetails GetAppointmentDetails(string _date_id)
        {
            sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", _date_id);
            var col = new string[] { "appointment_id", "customer_id", "service_id", "date_id" };
            var x = msSqlDataAccess.GetSingleRowDataList(sqlQuery, col).ToArray();

            return BuildAppointmentDetails(x);

            ////---------------
            //IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            //IDate date = kernel.Get<IDate>();
            //ICustomer customer = kernel.Get<ICustomer>();
            //IMyServices service = kernel.Get<IMyServices>();

            //var customer_id = "";
            //var date_id = "";
            //var service_id = "";
            //var appointment_id = "";

            //try
            //{
            //    sqlConnection.Open();
            //    sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", _date_id);
            //    sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //    reader = sqlCommand.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            // odczyt wszystkich kolumn w accesssie, zwrot jako appDetails number

            //            customer_id = reader["customer_id"].ToString();
            //            service_id = reader["service_id"].ToString();
            //            date_id = reader["date_id"].ToString();
            //            appointment_id = reader["appointment_id"].ToString();
            //        }
            //    }
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //SetAppointmentDetails(appointment, out date, out customer, out service, customer_id, date_id, service_id);

            //return appointment;
        }
        public string GetAppointment_id(string day, string time)
        {
            IDate date = GetDate(day, time);
            string date_id = date.Date_Id;

            sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", date_id);
            var col = new string[] { "appointment_id", "customer_id", "service_id", "date_id" };
            var x = msSqlDataAccess.GetSingleRowDataList(sqlQuery, col).ToArray();

            return BuildAppointmentDetails(x).AppointmentId;
            ////--------------------

            //IDate date = kernel.Get<IDate>();
            //date = GetDate(day, time);
            //string date_id = date.Date_Id;
            //var customer_id = "";
            //var service_id = "";
            //var appointment_id = "";
            //try
            //{
            //    sqlConnection.Open();
            //    sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", date_id);
            //    sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            //    reader = sqlCommand.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            // odczyt wszystkich kolumn w accesssie

            //            customer_id = reader["customer_id"].ToString();
            //            service_id = reader["service_id"].ToString();
            //            date_id = reader["date_id"].ToString();
            //            appointment_id = reader["appointment_id"].ToString();
            //        }
            //    }
            //    sqlConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //return appointment_id;
        }

        private void SetAppointmentDetails(IAppointmentDetails appointment, out IDate date, out ICustomer customer, out IMyServices service, string customer_id, string date_id, string service_id)
        {
            date = GetDate(date_id);
            customer = GetCustomer(customer_id);
            service = GetService(service_id);

            appointment.Forename = customer.Forename;
            appointment.Surname = customer.Surname;
            appointment.Telephone = customer.Telephone;
            appointment.AppointmentDay = date.Day;
            appointment.AppointmentTime = date.Time;
            appointment.AppointmentDuration = date.Duration;
            appointment.AppointmentLength = date.Length;
            appointment.Name = service.Name;
        }



        private IDate GetDate(string date_id)
        {
            IDate date = kernel.Get<IDate>();
            IDateProcessor dateProcessor = kernel.Get<IDateProcessor>();

            query = string.Format("SELECT * FROM date WHERE date_id = '{0}'", date_id);
            var receivedData = msSqlDataAccess.GetData(query, date).ToArray();

            date = dateProcessor.CreateDate(receivedData);
            return date;
        }

        public IDate GetDate(string day, string time)
        {
            IDate date = kernel.Get<IDate>();
            IDateProcessor dateProcessor = kernel.Get<IDateProcessor>();

            query = string.Format("SELECT * FROM date WHERE day = '{0}' AND time = '{1}'", day, time);
            var receivedData = msSqlDataAccess.GetData(query, date).ToArray();

            date = dateProcessor.CreateDate(receivedData);
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
