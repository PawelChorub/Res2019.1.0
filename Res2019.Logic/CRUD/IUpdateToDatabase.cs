using Res2019.Logic.Events;
using Res2019.Logic.Models;
using System;
using static Res2019.UpdateToDatabase;

namespace Res2019
{
    public interface IUpdateToDatabase
    {
        event UpdatedToDatabaseHandler UpdatedToDatabase;

        void ModifyToSql(IAppointmentDetails appointmentDetails);

    }
}