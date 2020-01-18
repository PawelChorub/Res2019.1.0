using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.Logic.Events
{
    public class SmsConfirmation
    {
        public void OnSavedToDatabaseEventLog(object source, EventArgs e)
        {
            MessageBox.Show("Not implemented service. Fake Message: Wysłano SMS z potwierdzeniem");
        }
        public void OnUpdatedToDatabaseEventLog(object source, AppointmentEventArgs e)
        {
            MessageBox.Show("Not implemented service. Fake Message: Wysłano SMS z potwierdzeniem zmiany wizyty na: "
                + e.AppointmentDetails.AppointmentDay 
                + " godz :" + e.AppointmentDetails.AppointmentTime
                + " dla : " + e.AppointmentDetails.CustomerForename 
                + " " + e.AppointmentDetails.CustomerSurname);
        }
    }
}
