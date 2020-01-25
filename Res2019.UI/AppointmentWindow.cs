using Ninject;
using Res2019.Logic;
using System;
using System.Windows.Forms;

namespace Res2019
{
    public partial class AppointmentWindow : Form
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        IBusinessLogic businessLogic;
        public string Date { get; set; }
        public string Time { get; set; }
        public AppointmentWindow()
        {
            businessLogic = kernel.Get<IBusinessLogic>();
            InitializeComponent();
        }

        public AppointmentWindow(string _date, string _time)
        {
            businessLogic = kernel.Get<IBusinessLogic>();
            InitializeComponent();
            Date = _date;
            Time = _time;
            dateLabel.Text = _date;
            timeLabel.Text = _time;
        }

        private string Duration;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Duration = businessLogic.LabelSizeMultiplier(clientTimeComboBox.SelectedItem.ToString());

                businessLogic.AppointmentDetails(dateLabel.Text, timeLabel.Text, clientTimeComboBox.SelectedItem.ToString(), Duration, forenameTextBox.Text, surenameTextBox.Text, telephoneNumbtextBox.Text, serviceChoiceComboBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie podano kompletnych danych wizyty AppForm!" + ex.ToString());
            }
            Close();          
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Duration = "0";  // aby labele byly ok
            Close();
        }
    }
}
