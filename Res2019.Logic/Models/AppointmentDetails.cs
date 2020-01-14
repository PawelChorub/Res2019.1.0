﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class AppointmentDetails : IAppointment, ICustomer, IMyServices, IAppointmentDetails
    {

        public string AppointmentId { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentDuration { get; set; }
        public string AppointmentLength { get; set; }
        public string AppointmentTime { get; set; }
        public string IsOccupied { get; set; }
        public string CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerForename { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerTelephoneNumber { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}
