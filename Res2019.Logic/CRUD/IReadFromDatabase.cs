using Res2019.Logic.Models;
using System.Collections.Generic;

namespace Res2019
{
    public interface IReadFromDatabase
    {
        IAppointmentDetails ReturnAppointmentFromDatabase(string dataWizyty, string godzinaWizyty);
        List<IAppointmentDetails> ReturnListOfAppointmentsFromDatabase(string date);
    }
}