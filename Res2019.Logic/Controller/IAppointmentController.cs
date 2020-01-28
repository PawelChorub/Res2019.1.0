using System.Collections.Generic;
using Res2019.Logic.Models;
using static Res2019.Logic.Controller.AppointmentController;

namespace Res2019.Logic.Controller
{
    public interface IAppointmentController
    {
        event SaveToDatabaseHandler SaveToDatabaseEventLog;
        event UpdatedToDatabaseHandler UpdatedToDatabase;

        void DeleteAppointment(string appointment_id);
        IAppointmentDetails GetAppointment(string _appointment_id);
        IAppointmentDetails GetAppointment(string day, string time);
        IAppointmentDetails GetAppointmentDetails(string _date_id);
        string GetAppointment_id(string day, string time);
        List<IAppointmentDetails> GetListOfAppointment(string day);
        void SaveAppointment(string date_id, string customer_id, string service_id);
        void UpdateAppointment(IDate date, ICustomer customer, IMyServices service, string appointmentToModify_id);
    }
}