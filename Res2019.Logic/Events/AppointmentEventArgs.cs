using Res2019.Logic.Models;
using System;

namespace Res2019.Logic.Events
{
    public class AppointmentEventArgs : EventArgs
    {
        public IAppointmentDetails AppointmentDetails { get; set; }
    }
}
