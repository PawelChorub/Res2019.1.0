using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019
{
    public class SetNumberOfLabel : ISetNumberOfLabel
    {
        // ustawia numer labela w zaleznosci od wybranej godziny
        public string SetLabelNumber(string timeofAppointment)
        {
            HourOfAppointment hourOfAppointment = new HourOfAppointment();
            var output = hourOfAppointment.GetAppointmentHourKey(timeofAppointment);
            return output.ToString();
        }


    }
}
