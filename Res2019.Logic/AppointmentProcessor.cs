using Ninject;
using Res2019.Logic.Events;
using Res2019.Logic.Helpers;
using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.Logic
{
    public class AppointmentProcessor : IAppointmentProcessor
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        IReadFromDatabase readFromDatabase;
        IRemoveFromDatabase removeFromDatabase;
        ISaveToDatabase saveToDatabase;
        IUpdateToDatabase updateToDatabase;
        ITimeToEndOfWorkProcessor timeToEndOfWorkProcessor;
        IAppointmentDetails appointmentDetails;
        EmailConfirmation emailConfirmation;
        SmsConfirmation smsConfirmation;


        public AppointmentProcessor()
        {
            appointmentDetails = kernel.Get<IAppointmentDetails>();
            readFromDatabase = kernel.Get<IReadFromDatabase>();
            removeFromDatabase = kernel.Get<IRemoveFromDatabase>();
            saveToDatabase = kernel.Get<ISaveToDatabase>();
            updateToDatabase = kernel.Get<IUpdateToDatabase>();
            timeToEndOfWorkProcessor = kernel.Get<ITimeToEndOfWorkProcessor>();
            emailConfirmation = kernel.Get<EmailConfirmation>();
            smsConfirmation = kernel.Get<SmsConfirmation>();

        }
        //***
        public void BuildAppointment(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            bool IsTimeAvailable = false;
            string timeToCalculate = null;

            double.TryParse(appointment.AppointmentDuration, out double multiplier);
            DateTime.TryParse(appointment.AppointmentTime, out DateTime appointmentTime);

            int newTimeAppointmentInMinutes = (int)(60 * (multiplier / 2));

            // minuta po minucie sprawdzaj zajętość pola
            for (int i = 0; i < newTimeAppointmentInMinutes; i++)
            {
                timeToCalculate = appointmentTime.AddMinutes(i).ToShortTimeString();
                // kolizja z następnym terminem 
                if (readFromDatabase.GetDate(appointment.AppointmentDay, timeToCalculate).Date_Id == null)
                {
                    IsTimeAvailable = true;
                }
                else
                {
                    IsTimeAvailable = false;
                    break;
                }
            }

            IsTimeAvailable = CheckAvailableTimeToEndOfWorkInMinutes(appointment, IsTimeAvailable, newTimeAppointmentInMinutes);

            if (IsTimeAvailable)
            {
                try
                {
                    SaveAppointmentToDataBase(appointment, customer, service);
                }
                catch (Exception)
                {
                    MessageBox.Show("AppointmentProcessor Error");
                }
            }
            else
            {
                MessageBox.Show("Termin jest zajęty! Wybierz inny termin wizyty!");
            }
        }

        public void ModifyAppointment(IAppointment appointment, ICustomer customer, IMyServices service, string existingAppointmentDuration)
        {
            bool IsTimeAvailable = false;
            string timeToCalculate;
            // obliczanie minut wizyty na podstawie zakresu - 1 to jedna kratka, 30minut
            DateTime.TryParse(appointment.AppointmentTime, out DateTime appointmentTime);

            double.TryParse(appointment.AppointmentDuration, out double multiplier);
            double.TryParse(existingAppointmentDuration, out double existingMultiplier);

            int newTimeAppointmentInMinutes = (int)(60 * (multiplier / 2));
            int timeAppointmentMinutes = (int)(60 * (existingMultiplier / 2));

            if (timeAppointmentMinutes < newTimeAppointmentInMinutes)
            {
                // rozszerzam wizytę <
                for (int i = timeAppointmentMinutes; i < newTimeAppointmentInMinutes; i++)

                {   // sprawdź po minucie czy wolny zakres terminów
                    timeToCalculate = appointmentTime.AddMinutes(i).ToShortTimeString();

                    if (readFromDatabase.GetDate(appointment.AppointmentDay, timeToCalculate).Date_Id == null)
                    {
                        IsTimeAvailable = true;
                    }
                    else
                    {
                        IsTimeAvailable = false;
                        break;
                    }
                }
            }
            else
            {
                // skracam wizytę >=
                IsTimeAvailable = true;
            }

            // kontrola końca formularza / dnia
            IsTimeAvailable = CheckAvailableTimeToEndOfWorkInMinutes(appointment, IsTimeAvailable, newTimeAppointmentInMinutes);

            if (IsTimeAvailable)
            {
                try
                {
                    UpdateAppointmentToDatabase(appointment, customer, service);
                }
                catch (Exception)
                {
                    MessageBox.Show("AppointmentProcessor Error Modify Appointment Method");
                }
            }
            else
            {
                MessageBox.Show("Za mało dostępnego czasu do wykonania modyfikacji. Wybierz inny termin wizyty!");
            }
        }

        public void DeleteAppointment(IAppointment appointment)
        {
            if (!string.IsNullOrWhiteSpace(appointment.AppointmentDay) && !string.IsNullOrWhiteSpace(appointment.AppointmentTime))
            {
                string id = readFromDatabase.GetAppointment_id(appointment.AppointmentDay, appointment.AppointmentTime);
                string date_id = readFromDatabase.GetDate(appointment.AppointmentDay, appointment.AppointmentTime).Date_Id;

                removeFromDatabase.DeleteAppointment(id);
                removeFromDatabase.DeleteDate(date_id);               
            }
            else
            {
                MessageBox.Show("Wizyta nie została usunięta, z powodu niewystarczających danych!");
            }
        }

        public IAppointmentDetails ReadAppointment(string date, string time)
        {
            if (!string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(time))
            {
                return readFromDatabase.GetAppointment(date, time);
            }
            else
            {
                return null;
            }
        }

        public List<IAppointmentDetails> ReadAppointmentsToList(string date)
        {
            if (!string.IsNullOrWhiteSpace(date))
            {
                return readFromDatabase.GetListOfAppointment(date);
            }
            else
            {
                return null;
            }
        }
        private void SaveAppointmentToDataBase(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            IDate date = kernel.Get<IDate>();

            saveToDatabase.SaveToDatabaseEventLog += emailConfirmation.OnSavedToDatabaseEventLog;
            saveToDatabase.SaveToDatabaseEventLog += smsConfirmation.OnSavedToDatabaseEventLog;

            var date_id = readFromDatabase.GetDate(appointment.AppointmentDay, appointment.AppointmentTime).Date_Id;

            var customer_id = readFromDatabase.GetCustomer(customer).CustomerId;

            var service_id = readFromDatabase.GetService(service).ServiceId;

            if (CheckObjectsIsItsNotNull(appointment, customer, service))
            {
                if (string.IsNullOrEmpty(customer_id))    
                {
                    saveToDatabase.SaveCustomer(customer);
                    customer_id = readFromDatabase.GetCustomer(customer).CustomerId;
                }

                if (string.IsNullOrEmpty(date_id))
                {
                    date.DateDay = appointment.AppointmentDay;
                    date.DateTime = appointment.AppointmentTime;
                    date.DateLength = appointment.AppointmentLength;
                    date.DateDuration = appointment.AppointmentDuration;
                    saveToDatabase.SaveDate(date);

                    date_id = readFromDatabase.GetDate(date.DateDay, date.DateTime).Date_Id;
                    saveToDatabase.SaveAppointment(date_id, customer_id, service_id);
                }
                else
                {
                    MessageBox.Show("Termin zajęty NEW");
                }
            }
        }

        private static bool CheckObjectsIsItsNotNull(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            if ((!string.IsNullOrWhiteSpace(appointment.AppointmentDay)) &&
                    (!string.IsNullOrWhiteSpace(appointment.AppointmentTime)) &&
                    (!string.IsNullOrWhiteSpace(appointment.AppointmentLength)) &&
                    (!string.IsNullOrWhiteSpace(appointment.AppointmentDuration)) &&
                    (!string.IsNullOrWhiteSpace(customer.CustomerSurname)) &&
                    (!string.IsNullOrWhiteSpace(service.ServiceName)))

            {
                return true;
            }
            else return false;
        }

        private void UpdateAppointmentToDatabase(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            //updateToDatabase.UpdatedToDatabase += emailConfirmation.OnUpdatedToDatabaseEventLog;
            //updateToDatabase.UpdatedToDatabase += smsConfirmation.OnUpdatedToDatabaseEventLog;
            var date_id = readFromDatabase.GetDate(appointment.AppointmentDay, appointment.AppointmentTime);
            var customer_id = readFromDatabase.GetCustomer(customer);
            var service_id = readFromDatabase.GetService(service);
            var appointmentToModify_id = readFromDatabase.GetAppointment_id(appointment.AppointmentDay, appointment.AppointmentTime);

            if (CheckObjectsIsItsNotNull(appointment, customer, service))
            {
                if (string.IsNullOrWhiteSpace(customer_id.CustomerId))
                {
                    saveToDatabase.SaveCustomer(customer);
                    customer_id = readFromDatabase.GetCustomer(customer);
                }

                updateToDatabase.UpdateDate(date_id, appointment);

                updateToDatabase.UpdateAppointment(date_id, customer_id, service_id, appointmentToModify_id);
            }
        }

        private bool CheckAvailableTimeToEndOfWorkInMinutes(IAppointment appointment, bool IsTimeAvailable, int newTimeAppointmentInMinutes)
        {
            int AvailableTime = timeToEndOfWorkProcessor.CalculateTimeToEndOfWork(appointment.AppointmentTime);

            if (!(AvailableTime >= newTimeAppointmentInMinutes))
            {
                MessageBox.Show("Dzień pracy kończymy o godzinie 19:00, zmniejsz zarezerwowany czas!");
                IsTimeAvailable = false;
            }

            return IsTimeAvailable;
        }
    }
}
