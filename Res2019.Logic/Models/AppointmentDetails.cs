using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class AppointmentDetails : IAppointment, ICustomer, IMyServices, IAppointmentDetails
    {

        public string AppointmentId { get; set; }
        public string AppointmentDay { get; set; }
        public string AppointmentDuration { get; set; }
        public string AppointmentLength { get; set; }
        public string AppointmentTime { get; set; }
        public string IsOccupied { get; set; }
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Name { get; set; }
        public string Service_Id { get; set; }
    }
}
