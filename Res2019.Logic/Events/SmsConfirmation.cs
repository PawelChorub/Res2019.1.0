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
            MessageBox.Show("Not implemented service. Test Message: Wysłano SMS z potwierdzeniem");
        }
        public void OnUpdatedToDatabaseEventLog(object source, AppointmentEventArgs e)
        {
            MessageBox.Show("Not implemented service. Test Message:\nWysłano SMS z potwierdzeniem zmiany wizyty na:\n"
                + e.Date.Day 
                + "\ngodz :" + e.Date.Time
                + "\ndla : " + e.Customer.Forename
                + " " + e.Customer.Surname);
        }
    }
}
