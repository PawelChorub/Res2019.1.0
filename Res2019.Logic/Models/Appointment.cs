using Res2019.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class Appointment : IDateLibrary, ITimeLibrary, ILengthLibrary, IDurationLibrary, IOccupiedLibrary, IAppointment
    {
        
        public string AppointmentId { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentLength { get; set; }
        public string AppointmentDuration { get; set; }
        public string IsOccupied { get; set; }
    }
}
