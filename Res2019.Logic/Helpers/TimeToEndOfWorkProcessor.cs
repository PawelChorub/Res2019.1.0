using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Helpers
{
    public class TimeToEndOfWorkProcessor : ITimeToEndOfWorkProcessor
    {        
        private readonly int maxTimeOfWorkInMinutes = 690;

        public int CalculateTimeToEndOfWork(string appointmentTime)
        {
            int output;
            int foundKey = 0;

            HourOfAppointment hourOfAppointment = new HourOfAppointment();

            foreach (KeyValuePair<int, string> item in hourOfAppointment.GetAvailableHoursOfAppointmentCollection().Where(a => a.Value == appointmentTime))
            {
                foundKey = item.Key;
            }
            output = maxTimeOfWorkInMinutes - (foundKey * 30);
            return output;
        }
    }
}
