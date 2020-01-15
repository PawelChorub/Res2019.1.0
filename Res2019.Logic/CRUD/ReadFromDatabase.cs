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
                else
                {// do zapisu prototyp
                    app.DateDate = "2020-20-02";
                    app.DateTime = "10:00";
                    app.DateLength = "00:30";
                    app.DateDuration = "1";
                    app.Date_Id = "111";
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
