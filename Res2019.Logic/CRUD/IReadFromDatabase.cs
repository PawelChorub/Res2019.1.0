using Res2019.Logic.Models;
using System.Collections.Generic;

namespace Res2019
{
    public interface IReadFromDatabase
    {
        IDate GetDateFromDb(string dataWizyty, string godzinaWizyty);
        List<IAppointmentDetails> ReturnListOfAppointmentsFromDatabase(string date);
        IAppointmentDetails ReturnAppointmentFromDatabase(string dataWizyty, string godzinaWizyty);

        ICustomer GetCustomerFromDb(ICustomer customer);
        IMyServices GetServiceFromDb(IMyServices service);

        IDate GetDateFromDb_Specially(string dataWizyty, string godzinaWizyty);

        string GetAppointment_ID_FromDb(string day, string time);

        IAppointmentDetails GetAppointmentDetails_By_ID_FromDatabase(string id);




    }
}