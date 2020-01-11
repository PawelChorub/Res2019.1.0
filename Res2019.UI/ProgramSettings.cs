using Res2019.Logic;
using Res2019.MSSQL;
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
    public partial class ProgramSettings : Form
    {
        public ProgramSettings()
        {
            InitializeComponent();
        }
        private string sqlConnectionString = String.Format
        ("Server={0};User={1};Password={2};Database={3}",sqlServer, sqlLogin, sqlPassword, sqlDatabase);
        private static string sqlServer = ".\\SQLEXPR";

        private static string sqlDatabase = "ReservationSystem";
        private static string sqlReservationTable = "ReservationTable";

        private static string sqlPassword = "12trzy";
        private static string sqlLogin = "sa";
        private static string sqlConnection = "Server=.\\SQLEXPR;User=sa;Password=12trzy;Database=ReservationSystem";



        private void DefaultSettingsButton_Click(object sender, EventArgs e)
        {
        sqlDatabase = "ReservationSystem";
        sqlReservationTable = "ReservationTable";
        sqlPassword = "12trzy";
        sqlLogin = "sa";
        //sqlConnectionString = "Server=.\\SQLEXPR;User=sa;Password=12trzy;Database=ReservationSystem";
            textBox6.Text = sqlConnectionString;


        }

        private void OkButton_Click(object sender, EventArgs e)
        {
        }
    }
}
