using Res2019.Logic.Models;
using static Res2019.SaveToDatabase;

namespace Res2019
{
    public interface ISaveToDatabase
    {
        event SaveToDatabaseHandler SaveToDatabaseEventLog;

        void SaveToSql_New(string date_id, string customer_id, string service_id);
        void SaveNewDateToSql(IDate date);
        void SaveNewCustomerToSql(ICustomer customer);
    }
}