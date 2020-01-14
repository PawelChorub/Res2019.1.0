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

    }
}