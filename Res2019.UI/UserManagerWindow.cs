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
    public partial class UserManagerWindow : Form
    {
        IKernel kernel = new StandardKernel(new UserManagerContainerConfig());

        IUserStatus userStatus;
        IAccountManager accountManager;

        public UserManagerWindow()
        {
            userStatus = kernel.Get<IUserStatus>();
            accountManager = kernel.Get<IAccountManager>();

            InitializeComponent();
            LoadUsers(); // ładuje userów do comboBoxa
        }

        private string password;
        private string passwordConfirm;
        private string login;

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            SetCredentials();

            if ((!string.IsNullOrWhiteSpace(password)) && (!string.IsNullOrWhiteSpace(passwordConfirm)) && (!string.IsNullOrWhiteSpace(login)))
            {
                if ((IsPasswordConfirmed(password, passwordConfirm)))
                {
                    accountManager.CreateUserAccount(login,password);
                    UsersComboBox.Items.Clear();
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Potwierdzane hasło musi być zgodne z podanym hasłem!");
                }
            }
            else
            {
                MessageBox.Show("Musisz podać login i hasło!");
            }
        }

        private void SetCredentials()
        {
            password = PasswordTb.Text;
            passwordConfirm = ConfirmPasswordTb.Text;
            login = LoginTb.Text;
        }

        private bool IsPasswordConfirmed(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RemoveUserBtn_Click(object sender, EventArgs e)
        {
            string login = "";
            try
            {
                login = UsersComboBox.SelectedItem.ToString();
                if (!((userStatus.ReturnUser() == login) && (userStatus.ReturnStatus())))
                {
                    accountManager.RemoveUserAccount(login);
                    MessageBox.Show(string.Format("Użytkownik : {0} został usunięty.", login));
                    UsersComboBox.Items.Clear();
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Nie można usunąć zalogowanego użytkownika!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Należy wybrać użytkownika!");
            }
        }

        private void LoadUsers()
        {
            foreach (var item in accountManager.ReturnAllUsers())
            {
                UsersComboBox.Items.Add(item);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
