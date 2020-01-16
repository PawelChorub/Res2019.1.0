namespace Res2019
{
    public interface IRemoveFromDatabase
    {
        void RemoveAppointmentFromDatabase(string dateOfApp, string timeOfApp);
        void DeleteDateFromDatabase_NEW(string id);

        void DeleteAppointmentFromDatabase_NEW(string id);

    }
}