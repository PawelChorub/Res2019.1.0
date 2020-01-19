using Res2019.Logic.Models;
using System.Collections.Generic;

namespace Res2019
{
    public interface IReadFromDatabase
    {
        List<IAppointmentDetails> GetListOfAppointment(string date);
        IAppointmentDetails GetAppointment(string dataWizyty, string godzinaWizyty);
        ICustomer GetCustomer(ICustomer customer);
        IMyServices GetService(IMyServices service);
        IDate GetDate(string dataWizyty, string godzinaWizyty);
        string GetAppointment_id(string day, string time);

        IAppointmentDetails GetAppointment(string id);




    }
}