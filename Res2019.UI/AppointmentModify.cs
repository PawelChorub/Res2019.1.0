using Ninject;
using Res2019.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019
{
    public partial class AppointmentModify : Form
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        IBusinessLogic businessLogic;
        private string existAppointmentDuration;

        public AppointmentModify()
        {
            businessLogic = kernel.Get<IBusinessLogic>();
            InitializeComponent();
        }

        public AppointmentModify(string date, string time, string forename, string surname, string telephone, string appointmentDuration /*string service, string serviceLength*/)
        {
            businessLogic = kernel.Get<IBusinessLogic>();
            InitializeComponent();
            dateTextBox.Text = date;
            timeTextBox.Text = time;
            forenameTextBox.Text = forename;
            surnameTextBox.Text = surname;
            telephoneTextBox.Text = telephone;
            existAppointmentDuration = appointmentDuration;
        }
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                businessLogic.ModifyAppointmentDetails(
                    dateTextBox.Text, 
                    timeTextBox.Text, 
                    clientTimeComboBox.SelectedItem.ToString(), 
                    businessLogic.LabelSizeMultiplier(clientTimeComboBox.SelectedItem.ToString()),
                    forenameTextBox.Text, 
                    surnameTextBox.Text, 
                    telephoneTextBox.Text, 
                    serviceChoiceComboBox.SelectedItem.ToString(), 
                    existAppointmentDuration);
                Close();

            }
            catch
            {
                MessageBox.Show("Wykryto niekompletne dane wizyty. AppointmentModifyForm");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
