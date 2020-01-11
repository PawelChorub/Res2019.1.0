using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Res2019;

namespace Res2019.UI
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void AgendaBtn_Click(object sender, EventArgs e)
        {
            CredentialsWindow credentialsWindow = new CredentialsWindow();
            credentialsWindow.ShowDialog();
            this.SendToBack();
        }
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            ProgramSettings programSettings = new ProgramSettings();
            programSettings.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();            
        }

    }
}
