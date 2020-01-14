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

                if (readFromDatabase.GetDateFromDb(appointment.AppointmentDate, timeToCalculate) == null)
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

                    if (readFromDatabase.GetDateFromDb(appointment.AppointmentDate, timeToCalculate) == null)
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
            if (!string.IsNullOrWhiteSpace(appointment.AppointmentDate) && !string.IsNullOrWhiteSpace(appointment.AppointmentTime))

            {
                removeFromDatabase.RemoveAppointmentFromDatabase(appointment.AppointmentDate, appointment.AppointmentTime);
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
                return readFromDatabase.GetDateFromDb(date, time);
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
                return readFromDatabase.ReturnListOfAppointmentsFromDatabase(date);
            }
            else
            {
                return null;
            }
        }

        private void SaveAppointmentToDataBase(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            saveToDatabase.SaveToDatabaseEventLog += emailConfirmation.OnSavedToDatabaseEventLog;
            saveToDatabase.SaveToDatabaseEventLog += smsConfirmation.OnSavedToDatabaseEventLog;

            if (CheckObjectsIsItsNotNull(appointment, customer, service))
            {
                saveToDatabase.SaveToSql(appointment, customer, service);
            }
        }

        private static bool CheckObjectsIsItsNotNull(IAppointment appointment, ICustomer customer, IMyServices service)
        {
            if ((!string.IsNullOrWhiteSpace(appointment.AppointmentDate)) &&
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
            updateToDatabase.UpdatedToDatabase += emailConfirmation.OnUpdatedToDatabaseEventLog;
            updateToDatabase.UpdatedToDatabase += smsConfirmation.OnUpdatedToDatabaseEventLog;

            if (CheckObjectsIsItsNotNull(appointment, customer, service))
            {
                appointmentDetails.AppointmentDate = appointment.AppointmentDate;
                appointmentDetails.AppointmentTime = appointment.AppointmentTime;
                appointmentDetails.AppointmentLength = appointment.AppointmentLength;
                appointmentDetails.AppointmentDuration = appointment.AppointmentDuration;
                appointmentDetails.CustomerForename = customer.CustomerForename;
                appointmentDetails.CustomerSurname = customer.CustomerSurname;
                appointmentDetails.CustomerTelephoneNumber = customer.CustomerTelephoneNumber;
                appointmentDetails.ServiceName = service.ServiceName;

                updateToDatabase.ModifyToSql(appointmentDetails);
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
