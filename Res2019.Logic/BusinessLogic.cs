using Ninject;
using Res2019.Logic.Models;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.Logic
{
    public class BusinessLogic : IBusinessLogic
    {
        private IKernel kernel = new StandardKernel(new DI_Container());

        private IAppointmentProcessor appointmentProcessor;
        private IAppointment appointment;
        private ICustomer customer;
        private IMyServices service;
        private IDayCounting dayCounting;
        private IDateFormatCheck dateFormatCheck;
        private ITimeFromLabel timeFromLabel;
        private ISetNumberOfLabel setNumberOfLabel;
        private ISetValueToLabelSize setValueToLabelSize;

        public BusinessLogic()
        {
            appointment = kernel.Get<IAppointment>();
            appointmentProcessor = kernel.Get<IAppointmentProcessor>();
            customer = kernel.Get<ICustomer>();
            dayCounting = kernel.Get<IDayCounting>();
            dateFormatCheck = kernel.Get<IDateFormatCheck>();
            service = kernel.Get<IMyServices>();
            setNumberOfLabel = kernel.Get<ISetNumberOfLabel>();
            setValueToLabelSize = kernel.Get<ISetValueToLabelSize>();
            timeFromLabel = kernel.Get<ITimeFromLabel>();
        }

        public void AppointmentDetails(string date, string time, string length, string duration, string forename, string surname, string tel, string _service)
        {
            appointment.AppointmentDay = date;
            appointment.AppointmentTime = time;
            appointment.AppointmentLength = length;
            appointment.AppointmentDuration = duration;
            customer.Forename = forename;
            customer.Surname = surname;
            customer.Email = "email";
            customer.Telephone = tel;
            service.Name = _service;

            appointmentProcessor.BuildAppointment(appointment, customer, service);
        }

        public void ModifyAppointmentDetails(string date, string time, string length, string duration, string forename, string surname, string tel, string _service, string existAppDuration)
        {
            appointment.AppointmentDay = date;
            appointment.AppointmentTime = time;
            appointment.AppointmentLength = length;
            appointment.AppointmentDuration = duration;
            customer.Forename = forename;
            customer.Surname = surname;
            customer.Email = "email";
            customer.Telephone = tel;
            service.Name = _service;

            appointmentProcessor.ModifyAppointment(appointment, customer, service, existAppDuration);
        }
        public void DeleteAppointment(string date, string time)
        {
            appointment.AppointmentDay = date;
            appointment.AppointmentTime = time;

            appointmentProcessor.DeleteAppointment(appointment);
        }

        public IAppointmentDetails ReadSingleAppointment(string date, string time)
        {
            return appointmentProcessor.ReadAppointment(date, time);

        }
        public List<IAppointmentDetails> ReadListOfAppointments(string date)
        {
            return appointmentProcessor.ReadAppointmentsToList(date);
        }

        public string DateSet(string date, int manipulation)
        {
            return dayCounting.SetPreviousOrNextDay(date, manipulation);
        }
        public string CurrentDateSet()
        {
            return dayCounting.SetCurrentDate();
        }

        public bool DateFormat(string date)
        {
            if ((dateFormatCheck.Check_YYYY_MM_DD_Format(date)))
            {
                return true;
            }
            else return false;
        }

        public string SetTimeByLabel(string _labelName)
        {
            return timeFromLabel.GetTimeFromLabel(_labelName);
        }

        public string SetNumberOfLabel(string _timeOfAppointment)
        {
            return setNumberOfLabel.SetLabelNumber(_timeOfAppointment);
        }
        
        public string LabelSizeMultiplier(string _valueIn)
        {
            return setValueToLabelSize.TimeToMultiplierCalculate(_valueIn);
        }
    }
}
