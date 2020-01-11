using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class TimeOfAppointment
    {
        private Dictionary<int, string> AvailableTimeOfAppointment = new Dictionary<int, string>()
        {
            {1, "0:30" },
            {2, "1:00" },
            {3, "1:30" },
            {4, "2:00" },
            {5, "2:30" },
            {6, "3:00" },
        };

        public int GetAppointmentTimeKey(string input)
        {
            int output = 0;
            foreach (KeyValuePair<int, string> item in AvailableTimeOfAppointment.Where(a => a.Value == input))
            {
                output = item.Key;
            }
            return output;
        }
    }
}
