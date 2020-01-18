using Ninject;
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
    public class ReadFromDatabase : IReadFromDatabase
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());
        private static IMsSqlDatabaseSettings connectionString = DatabaseManager.CreateMsSqlDatabaseSettings();
    
        private static SqlConnection sqlConnection_New = new SqlConnection(connectionString.MsSqlConnectionStringBuild_New());
        
        private static SqlCommand sqlCommand;
        private static SqlDataReader reader;
        private string sqlQuery = "";

        private readonly static string table = connectionString.UseReservationTableName();

        //new
        public List<string> GetDateFromDb_ByDay(string dataWizyty)
        {
            List<string> output = new List<string>();

            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM date WHERE day = '{0}'", dataWizyty);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output.Add(reader["date_id"].ToString());
                    }
                }
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return output;
        }

        public List<IAppointmentDetails> ReturnListOfAppointmentsFromDatabase(string date)
        {
            List<IAppointmentDetails> listOfApp = new List<IAppointmentDetails>();

            var date_id_List = GetDateFromDb_ByDay(date);

            foreach (var item in date_id_List)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    try
                    {
                        listOfApp.Add(GetAppointmentDetailsByDate_id(item));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            return listOfApp;
        }
        // new
        public IAppointmentDetails ReturnAppointmentFromDatabase(string dataWizyty, string godzinaWizyty)
        {
            IAppointmentDetails appointment = null;
            string id = GetAppointment_idByDayAndTime(dataWizyty, godzinaWizyty);
            if (!string.IsNullOrWhiteSpace(id))
            {
                appointment = kernel.Get<IAppointmentDetails>();
                appointment = GetAppointmentDetailsByAppointment_id(id);
            }
            return appointment;
        }
        // ustawic lentghy
        public IAppointmentDetails GetAppointmentDetailsByAppointment_id(string id)
        {
            IAppointmentDetails appointment = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();

            if (!string.IsNullOrEmpty(id))
            {
                var customer_id = "";
                var date_id = "";
                var service_id = "";

                try
                {
                    sqlConnection_New.Open();
                    sqlQuery = string.Format("SELECT * FROM appointment WHERE appointment_id = '{0}'", id);

                    sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
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
                    sqlConnection_New.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                date = GetDateByDate_id(date_id);
                customer = GetCustomerByCustomer_id(customer_id);
                service = GetServiceByService_id(date_id);

                appointment.CustomerForename = customer.CustomerForename;
                appointment.CustomerSurname = customer.CustomerSurname;
                appointment.CustomerTelephoneNumber = customer.CustomerTelephoneNumber;
                appointment.AppointmentDate = date.DateDay;
                appointment.AppointmentTime = date.DateTime;
                appointment.AppointmentDuration = date.DateDuration;
                appointment.AppointmentLength = date.DateLength;
                appointment.ServiceName = service.ServiceName;
            }
            return appointment;
        }
        public IAppointmentDetails GetAppointmentDetailsByDate_id(string id)
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
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", id);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
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
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            date = GetDateByDate_id(date_id);
            customer = GetCustomerByCustomer_id(customer_id);
            service = GetServiceByService_id(service_id);

            appointment.CustomerForename = customer.CustomerForename;
            appointment.CustomerSurname = customer.CustomerSurname;
            appointment.CustomerTelephoneNumber = customer.CustomerTelephoneNumber;
            appointment.AppointmentDate = date.DateDay;
            appointment.AppointmentTime = date.DateTime;
            appointment.AppointmentDuration = date.DateDuration;
            appointment.AppointmentLength = date.DateLength;
            appointment.ServiceName = service.ServiceName;
            return appointment;
        }

        private IMyServices GetServiceByService_id(string id)
        {
            IMyServices service = kernel.Get<IMyServices>();

            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM service WHERE service_id = '{0}'", id);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        service.ServiceName = reader["serviceName"].ToString();                      
                    }
                }
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return service;

        }

        private ICustomer GetCustomerByCustomer_id(string id)
        {
            ICustomer customer = kernel.Get<ICustomer>();
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM customer WHERE customer_id = '{0}'",
                                    id);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customer.CustomerForename = reader["forename"].ToString();
                        customer.CustomerSurname = reader["surname"].ToString();
                        customer.CustomerTelephoneNumber = reader["telephoneNumber"].ToString();
                        customer.CustomerId = reader["customer_id"].ToString();
                    }
                }
                sqlConnection_New.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return customer;

        }

        private IDate GetDateByDate_id(string id)
        {
            IDate date = kernel.Get<IDate>();

            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM date WHERE date_id = '{0}'", id);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
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

                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return date;
        }

        public string GetAppointment_idByDayAndTime(string day, string time)
        {
            IDate date = kernel.Get<IDate>();

            date = GetDateByDayAndTime(day, time);

            string search = date.Date_Id;

            string output = "";
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM appointment WHERE date_id = '{0}'", search);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output = reader["appointment_id"].ToString();             
                    }
                }
                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return output;
        }

        //public IDate GetDateByDayAndTime(string day, string time)
        //{
        //    IDate date = kernel.Get<IDate>();

        //    try
        //    {
        //        sqlConnection_New.Open();
        //        sqlQuery = string.Format("SELECT * FROM date WHERE day = '{0}' AND time = '{1}'", day, time);

        //        sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
        //        reader = sqlCommand.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                date.DateDay = reader["day"].ToString();
        //                date.DateTime = reader["time"].ToString();
        //                date.DateLength = reader["length"].ToString();
        //                date.DateDuration = reader["duration"].ToString();
        //                date.Date_Id = reader["date_id"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            date = null;
        //        }

        //        sqlConnection_New.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return date;
        //}
        public IDate GetDateByDayAndTime(string dataWizyty, string godzinaWizyty)
        {
            IDate app = kernel.Get<IDate>();

            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM date WHERE day = '{0}' AND time = '{1}'", dataWizyty, godzinaWizyty);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        app.DateDay = reader["day"].ToString();
                        app.DateTime = reader["time"].ToString();
                        app.DateLength = reader["length"].ToString();
                        app.DateDuration = reader["duration"].ToString();
                        app.Date_Id = reader["date_id"].ToString();
                    }
                }

                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return app;
        }



        public ICustomer GetCustomerFromDb(ICustomer customer)
        {
            ICustomer output = kernel.Get<ICustomer>();
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM customer WHERE forename = '{0}' AND surname = '{1}' AND telephoneNumber = '{2}'",
                                    customer.CustomerForename, customer.CustomerSurname, customer.CustomerTelephoneNumber);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output.CustomerForename = reader["forename"].ToString();
                        output.CustomerSurname = reader["surname"].ToString();
                        output.CustomerTelephoneNumber = reader["telephoneNumber"].ToString();
                        output.CustomerId = reader["customer_id"].ToString();
                    }
                }
                sqlConnection_New.Close();

            }
            catch (Exception)
            {
                throw;
            }
            return output;
        }
        public IMyServices GetServiceFromDb(IMyServices service)
        {
            IMyServices output = kernel.Get<IMyServices>();
            try
            {
                sqlConnection_New.Open();
                sqlQuery = string.Format("SELECT * FROM service WHERE serviceName = '{0}'",
                                    service.ServiceName);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection_New);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output.ServiceId = reader["service_id"].ToString();
                        output.ServiceName = reader["serviceName"].ToString();                     
                    }
                }
                sqlConnection_New.Close();

            }
            catch (Exception)
            {
                sqlConnection_New.Close();

                throw;
            }
            return output;
        }

    }
}
