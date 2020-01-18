using Ninject;
using Res2019.Logic;
using Res2019.MSSQL;
using Res2019.UsersManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Res2019.UserManager
{
    public class AccountManager : IAccountManager
    {
        IKernel kernel = new StandardKernel(new UserManagerContainerConfig());

        private IUserStatus userStatus;
        private ISCryptHashing sCryptHash;
        private static IMsSqlDatabaseSettings connectionString = DatabaseManager.CreateMsSqlDatabaseSettings();
        private static SqlConnection sqlConnection = new SqlConnection(connectionString.MsSqlConnectionStringBuild_New());
        private static SqlCommand sqlCommand;
        private static SqlDataReader sqlDataReader;
        private string sqlQuery = "";
        private readonly static string table = connectionString.UseUsersTable();

        public AccountManager()
        {
            userStatus = kernel.Get<IUserStatus>();
            sCryptHash = kernel.Get<ISCryptHashing>();
        }

        public void CreateUserAccount(string login, string password)
        {
            List<string> existingLogin = new List<string>();
            sqlConnection.Open();
            sqlQuery = string.Format("SELECT * FROM {0} WHERE Login = '{1}'", table, login);
            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlDataReader =  sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    existingLogin.Add(sqlDataReader["Login"].ToString());
                }
            }
            sqlConnection.Close();

            if (existingLogin.Count == 0)
            {
                string passwordHash = sCryptHash.Encode(password);
                sqlConnection.Open();
                sqlQuery = string.Format("INSERT INTO {0} (Login, Password) VALUES ('{1}', '{2}')", table, login, passwordHash);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Login jest zajęty, wybierz inną nazwę");
            }
        }
         
        public void VerifyUserAccount(string login, string password)
        {
            string userLogin = "";
            string passwordHash = "";

            try
            {
                sqlConnection.Open();
                sqlQuery = string.Format("SELECT * FROM {0} WHERE Login = '{1}'", table, login);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        userLogin = sqlDataReader["Login"].ToString();
                        passwordHash = sqlDataReader["Password"].ToString();
                    }
                }
                sqlConnection.Close();

                if ((login == userLogin) && (login != ""))
                {
                    if (sCryptHash.Verify(password, passwordHash))
                    {
                        userStatus.SetStatus(true, login);
                    }
                    else
                    {
                        userStatus.SetStatus(false, login);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LogOut()
        {
            userStatus.SetStatus(false, "");
        }

        public void RemoveUserAccount(string login)
        {
            List<string> existingLogin = new List<string>();
            sqlConnection.Open();
            sqlQuery = string.Format("SELECT * FROM {0} WHERE Login = '{1}'", table, login);
            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    existingLogin.Add(sqlDataReader["Login"].ToString());
                }
            }
            sqlConnection.Close();

            if (existingLogin.Count > 0)
            {
                sqlConnection.Open();
                sqlQuery = string.Format("DELETE FROM {0} WHERE Login = '{1}'", table, login);
                sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Nie znaleziono podanego loginu. Usunięcie jest niemożliwe.");
            }
        }
        public List<string> ReturnAllUsers()
        {
            List<string> Users = new List<string>();

            sqlConnection.Open();
            sqlQuery = string.Format("SELECT * FROM {0}", table);
            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Users.Add(sqlDataReader["Login"].ToString());
                }
            }
            sqlConnection.Close();
            return Users;
        }
        // to do poszczególnych okien
        //private void UserStatus()
        //{
        //    LoginStatus ls = new LoginStatus();

        //    if (ls.ReturnStatus())
        //    {
        //        colorLbl.BackColor = Color.Green;
        //        UserLbl.Text = ls.ReturnUser();
        //        StatusLbl.Text = "Zalogowany";
        //    }
        //    else
        //    {
        //        colorLbl.BackColor = Color.Red;
        //        UserLbl.Text = "";
        //        StatusLbl.Text = "";
        //    }

        //}

    }
}
