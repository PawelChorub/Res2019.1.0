using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019
{
    public class TimeFromLabel : ITimeFromLabel
    {
        public string GetTimeFromLabel(string labelName)
        {
            HourOfAppointment hourOfAppointment = new HourOfAppointment();
                      
            string[] namePartial = labelName.Split('_');
            int.TryParse(namePartial[1], out int output);

            return hourOfAppointment.GetAppointmentHourValue(output);
        }
    }
}
