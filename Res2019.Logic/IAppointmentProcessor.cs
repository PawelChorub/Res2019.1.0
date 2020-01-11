using Res2019.Logic.Models;
using System.Collections.Generic;

namespace Res2019.Logic
{
    public interface IAppointmentProcessor
    {
        void BuildAppointment(IAppointment appointment, ICustomer customer, IMyServices service);
        void ModifyAppointment(IAppointment appointment, ICustomer customer, IMyServices service, string _existAppDuration);
        void DeleteAppointment(IAppointment appointment);
        List<IAppointmentDetails> ReadAppointmentsToList(string date);
        IAppointmentDetails ReadAppointment(string date, string time);
    }
}