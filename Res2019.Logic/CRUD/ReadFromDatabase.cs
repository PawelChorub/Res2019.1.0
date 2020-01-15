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
    
        private static SqlConnection sqlConnection = new SqlConnection(connectionString.MsSqlConnectionStringBuild());
        private static SqlConnection sqlConnection_New = new SqlConnection(connectionString.MsSqlConnectionStringBuild_New());
        
        private static SqlCommand sqlCommand;
        private static SqlDataReader reader;
        private string sqlQuery = "";

        private readonly static string table = connectionString.UseReservationTableName();

        public List<IAppointmentDetails> ReturnListOfAppointmentsFromDatabase(string date)
        {
            List<IAppointmentDetails> listOfApp = new List<IAppointmentDetails>();

            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM {1} WHERE appointmentDate = '{0}'", date, table);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IAppointmentDetails app = kernel.Get<IAppointmentDetails>();

                        app.AppointmentDate = reader["appointmentDate"].ToString();
                        app.AppointmentTime = reader["appointmentTime"].ToString();
                        app.AppointmentLength = reader["appointmentLength"].ToString();
                        app.AppointmentDuration = reader["appointmentDuration"].ToString();
                        app.CustomerForename = reader["customerForename"].ToString();
                        app.CustomerSurname = reader["customerSurname"].ToString();
                        app.CustomerTelephoneNumber = reader["customerTelephoneNumber"].ToString();
                        app.CustomerEmail = reader["customerEmail"].ToString();
                        app.ServiceName = reader["serviceName"].ToString();
                        app.IsOccupied = reader["isOccupied"].ToString();

                        listOfApp.Add(app);                        
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return listOfApp;
        }
        // old
        public IAppointmentDetails ReturnAppointmentFromDatabase(string dataWizyty, string godzinaWizyty)
        {
            IAppointmentDetails app = kernel.Get<IAppointmentDetails>();

            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM ReservationTable WHERE appointmentDate = '{0}' AND appointmentTime = '{1}'", dataWizyty, godzinaWizyty);

                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        app.AppointmentDate = reader["appointmentDate"].ToString();
                        app.AppointmentTime = reader["appointmentTime"].ToString();
                        app.AppointmentLength = reader["appointmentLength"].ToString();
                        app.AppointmentDuration = reader["appointmentDuration"].ToString();
                        app.CustomerForename = reader["customerForename"].ToString();
                        app.CustomerSurname = reader["customerSurname"].ToString();
                        app.CustomerTelephoneNumber = reader["customerTelephoneNumber"].ToString();
                        app.CustomerEmail = reader["customerEmail"].ToString();
                        app.ServiceName = reader["serviceName"].ToString();
                        app.IsOccupied = reader["isOccupied"].ToString();
                    }
                }
                else
                {
                    app = null;
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return app;
        }
        public IAppointmentDetails GetAppointmentDetails_By_ID_FromDatabase(string id)
        {
            IAppointmentDetails app = kernel.Get<IAppointmentDetails>();
            IDate date = kernel.Get<IDate>();
            ICustomer customer = kernel.Get<ICustomer>();
            IMyServices service = kernel.Get<IMyServices>();


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
            date = GetDateFromDb_Specially_ById(date_id);
            customer = GetCustomerFromDb_ById(customer_id);
            service = GetServiceFromDb_ById(date_id);

            app.CustomerForename = customer.CustomerForename;
            app.CustomerSurname = customer.CustomerSurname;
            app.CustomerTelephoneNumber = customer.CustomerTelephoneNumber;
            app.AppointmentDate = date.DateDate;
            app.AppointmentTime = date.DateTime;
            app.ServiceName = service.ServiceName;
            return app;
        }

        private IMyServices GetServiceFromDb_ById(string id)
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

        private ICustomer GetCustomerFromDb_ById(string id)
        {
            ICustomer output = kernel.Get<ICustomer>();
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

        private IDate GetDateFromDb_Specially_ById(string id)
        {
            IDate output = kernel.Get<IDate>();

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
                        output.DateDate = reader["day"].ToString();
                        output.DateTime = reader["time"].ToString();
                        output.DateLength = reader["length"].ToString();
                        output.DateDuration = reader["duration"].ToString();
                        output.Date_Id = reader["date_id"].ToString();
                    }
                }
                else
                {
                    output = null;
                }

                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return output;
        }

        public string GetAppointment_ID_FromDb(string day, string time)
        {
            IDate app = kernel.Get<IDate>();

            app = GetDateFromDb_Specially(day, time);

            string search = app.Date_Id;

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

        public IDate GetDateFromDb(string dataWizyty, string godzinaWizyty)
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
                        app.DateDate = reader["day"].ToString();
                        app.DateTime = reader["time"].ToString();
                        app.DateLength = reader["length"].ToString();
                        app.DateDuration = reader["duration"].ToString();
                        app.Date_Id = reader["date_id"].ToString();
                    }
                }
                else
                {
                    app = null;
                }

                sqlConnection_New.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return app;
        }
        public IDate GetDateFromDb_Specially(string dataWizyty, string godzinaWizyty)
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
                        app.DateDate = reader["day"].ToString();
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
