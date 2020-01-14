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
        public ICustomer GetCustomerFromDb(ICustomer customer)
        {
            ICustomer output = null;
            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT FROM //tableName// WHERE customerForename = '{0}' AND customerSurname = '{1}' AND customerTelephoneNumber = '{2}')",
                                    customer.CustomerForename, customer.CustomerSurname, customer.CustomerTelephoneNumber);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        output.CustomerForename = reader["customerForename"].ToString();
                        output.CustomerSurname = reader["customerSurename"].ToString();
                        output.CustomerTelephoneNumber = reader["customerTelephoneNumber"].ToString();
                        //output.CustomerId = reader["customer_id"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return output;
        }
    }
}
