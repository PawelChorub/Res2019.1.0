using System;
using System.Windows.Forms;

namespace Res2019.Logic.Events
{
    public class EmailConfirmation
    {
        public void OnSavedToDatabaseEventLog(object source, EventArgs e)
        {
            MessageBox.Show("Not implemented service. Test Message: Wysłano E-mail z potwierdzeniem");
        }
        public void OnUpdatedToDatabaseEventLog(object source, AppointmentEventArgs e)
        {
            MessageBox.Show("Not implemented service. Test Message:\nWysłano E-mail z potwierdzeniem zmiany wizyty:\n" + e.Date.Day
                 + "\ngodz :" + e.Date.Time
                 + "\ndla : " + e.Customer.Forename
                 + " " + e.Customer.Surname);
        }
    }
}
