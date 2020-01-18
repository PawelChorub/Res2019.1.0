using Ninject;
using Res2019.UserManager;
using Res2019.UsersManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.UI
{
    public partial class CredentialsWindow : Form
    {
        IKernel kernel = new StandardKernel(new UserManagerContainerConfig());

        IUserStatus userStatus;
        IAccountManager accountManager;

        public CredentialsWindow()
        {
            userStatus = kernel.Get<IUserStatus>();
            accountManager = kernel.Get<IAccountManager>();
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            accountManager.VerifyUserAccount(loginTb.Text, passwordTb.Text);
            if (userStatus.GetUserStatus())
            {
                Agenda agenda = new Agenda();
                agenda.Show();
                agenda.BringToFront();
                Close();
            }
            else
            {
                MessageBox.Show("Błąd logowania");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
