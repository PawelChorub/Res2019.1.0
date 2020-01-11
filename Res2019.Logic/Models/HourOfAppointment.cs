using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class HourOfAppointment
    {
        private Dictionary<int, string> AvailableHoursOfAppointment = new Dictionary<int, string>()
        {
            {1, "8:00" },
            {2, "8:30" },
            {3, "9:00" },
            {4, "9:30" },
            {5, "10:00"},
            {6, "10:30"},
            {7, "11:00"},
            {8, "11:30"},
            {9, "12:00"},
            {10, "12:30"},
            {11, "13:00"},
            {12, "13:30"},
            {13, "14:00"},
            {14, "14:30"},
            {15, "15:00"},
            {16, "15:30"},
            {17, "16:00"},
            {18, "16:30"},
            {19, "17:00"},
            {20, "17:30"},
            {21, "18:00"},
            {22, "18:30"}
        };

        public Dictionary<int, string> GetAvailableHoursOfAppointmentCollection()
        {
            return AvailableHoursOfAppointment;
        }
        public int GetAppointmentHourKey(string input)
        {
            int output = 0;

            foreach (KeyValuePair<int, string> item in AvailableHoursOfAppointment.Where(a => a.Value == input))
            {
                output = item.Key;
            }
            return output;            
        }
        public string GetAppointmentHourValue(int input)
        {

            string output = "";

            foreach (KeyValuePair<int, string> item in AvailableHoursOfAppointment.Where(a => a.Key == input))
            {
                output = item.Value;
            }
            return output;
        }

    }
}

