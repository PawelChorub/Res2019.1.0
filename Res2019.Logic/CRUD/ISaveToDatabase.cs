using Res2019.Logic.Models;
using static Res2019.SaveToDatabase;

namespace Res2019
{
    public interface ISaveToDatabase
    {
        event SaveToDatabaseHandler SaveToDatabaseEventLog;

        //void SaveToSql(string date, string time, string length, string duration, string fname, string sname, string telnumb, string service);
        void SaveToSql(IAppointment appointment, ICustomer customer, IMyServices service);
    }
}