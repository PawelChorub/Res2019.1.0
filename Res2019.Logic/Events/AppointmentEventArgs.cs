using Res2019.Logic.Models;
using System;

namespace Res2019.Logic.Events
{
    public class AppointmentEventArgs : EventArgs
    {
        public IDate Date { get; set; }
        public ICustomer Customer { get; set; }
        public IMyServices Service { get; set; }
    }
}
