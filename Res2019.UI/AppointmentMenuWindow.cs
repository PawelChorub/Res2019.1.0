using Ninject;
using Res2019.Logic;
using Res2019.Logic.Models;
using System;
using System.Windows.Forms;

namespace Res2019
{
    public partial class AppointmentMenuWindow : Form
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        IBusinessLogic businessLogic;
        private string date;
        private string time;

        public AppointmentMenuWindow()
        {
            businessLogic = kernel.Get<IBusinessLogic>();
            InitializeComponent();
        }

        public AppointmentMenuWindow(string dateOfAppointment, string timeOfAppointment)
        {
            businessLogic = kernel.Get<IBusinessLogic>();
            InitializeComponent();
            label1.Text = dateOfAppointment;
            label2.Text = timeOfAppointment;
            date = dateOfAppointment;
            time = timeOfAppointment;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentWindow appointmentWindow = new AppointmentWindow(date, time);
                Close();
                appointmentWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd : \n" + ex);
            }
        }

        private void RemoveAppointmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (businessLogic.ReadSingleAppointment(date, time) != null)
                {
                    if (MessageBox.Show("Potwierdź usunięcie wizyty.", "Usuwanie...", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        businessLogic.DeleteAppointment(date, time);
                        Close();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nie możesz usunąć pustego pola.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd : \n" + ex);
            }
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                IAppointmentDetails appointmentDetails;
                appointmentDetails = businessLogic.ReadSingleAppointment(date, time);
                if (appointmentDetails != null)
                {
                    AppointmentModifyWindow appointmentModifyWindow = new AppointmentModifyWindow(
                        date, time, appointmentDetails.CustomerForename, appointmentDetails.CustomerSurname,
                        appointmentDetails.CustomerTelephoneNumber, appointmentDetails.AppointmentDuration);
                    appointmentModifyWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nie możesz modyfikować pustego pola.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd : \n" + ex);
            }

            //try
            //{
            //    IAppointmentDetails appointmentDetails = businessLogic.ReadSingleAppointment(date, time);

            //    if (appointmentDetails != null)
            //    {
            //        AppointmentModify am = new AppointmentModify(
            //            date, time, appointmentDetails.CustomerForename, appointmentDetails.CustomerSurname, 
            //            appointmentDetails.CustomerTelephoneNumber, appointmentDetails.AppointmentDuration);
            //        am.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Nie możesz modyfikować pustego pola.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Błąd : \n" + ex);
            //}
        }
    }
}
