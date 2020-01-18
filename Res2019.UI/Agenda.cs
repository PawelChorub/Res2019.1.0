using Ninject;
using Res2019.Logic;
using Res2019.Logic.Models;
using Res2019.UI;
using Res2019.UserManager;
using Res2019.UsersManager;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Res2019
{
    public partial class Agenda : Form
    {
        IKernel kernelUserManager = new StandardKernel(new UserManagerContainerConfig());
        IKernel kernel = new StandardKernel(new DI_Container());
        IUserStatus userStatus;
        IAccountManager accountManager;
        IBusinessLogic businessLogic;
        private string labelTextBuffer;
        private string setTimeFromLabel;
        private string setDateFromLabel;

        public Agenda()
        {
            userStatus = kernelUserManager.Get<IUserStatus>();
            accountManager = kernelUserManager.Get<IAccountManager>();
            InitializeComponent();
            businessLogic = kernel.Get<IBusinessLogic>();
            SetDateOnStart(businessLogic.CurrentDateSet());            // inicjalizacja dat
            SectionSetToDefaultMulti();                     //ustaw labele na default
            SectionFillMulti();                             // wypelnij wszystkie
            SetUserName();
        }

        public void SectionSetToDefaultMulti()      
        {
            for (int i = 1; i <= 7; i++)
            {
                SectionSetToDefault("Label" + i + "_", 1, 22);
            }
        }
        public void SectionFillMulti()
        {
            SectionFill("Label1_", day1Label.Text);
            SectionFill("Label2_", day2Label.Text);
            SectionFill("Label3_", day3Label.Text);
            SectionFill("Label4_", day4Label.Text);
            SectionFill("Label5_", day5Label.Text);
            SectionFill("Label6_", day6Label.Text);
            SectionFill("Label7_", day7Label.Text);
        }

        private void SetDateOnStart(string dayWithStarting)
        {
            day1Label.Text = dayWithStarting;
            day2Label.Text = businessLogic.DateSet(day1Label.Text, 1);
            day3Label.Text = businessLogic.DateSet(day2Label.Text, 1);
            day4Label.Text = businessLogic.DateSet(day3Label.Text, 1);
            day5Label.Text = businessLogic.DateSet(day4Label.Text, 1);
            day6Label.Text = businessLogic.DateSet(day5Label.Text, 1);
            day7Label.Text = businessLogic.DateSet(day6Label.Text, 1);
        }
        private void PrevBtn_Click(object sender, EventArgs e)
        {
            day1Label.Text = businessLogic.DateSet(day1Label.Text, -1);
            day2Label.Text = businessLogic.DateSet(day2Label.Text, -1);
            day3Label.Text = businessLogic.DateSet(day3Label.Text, -1);
            day4Label.Text = businessLogic.DateSet(day4Label.Text, -1);
            day5Label.Text = businessLogic.DateSet(day5Label.Text, -1);
            day6Label.Text = businessLogic.DateSet(day6Label.Text, -1);
            day7Label.Text = businessLogic.DateSet(day7Label.Text, -1);
            SectionSetToDefaultMulti();                     
            SectionFillMulti();                             
        }
        private void NextBtn_Click(object sender, EventArgs e)
        {
            day1Label.Text = businessLogic.DateSet(day1Label.Text, 1);
            day2Label.Text = businessLogic.DateSet(day2Label.Text, 1);
            day3Label.Text = businessLogic.DateSet(day3Label.Text, 1);
            day4Label.Text = businessLogic.DateSet(day4Label.Text, 1);
            day5Label.Text = businessLogic.DateSet(day5Label.Text, 1);
            day6Label.Text = businessLogic.DateSet(day6Label.Text, 1);
            day7Label.Text = businessLogic.DateSet(day7Label.Text, 1);
            SectionSetToDefaultMulti();                     
            SectionFillMulti();                             
        }
        private void JumpToDateButton_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;

            if (businessLogic.DateFormat(date))
            {
                SetDateOnStart(date);
                SectionSetToDefaultMulti();
                SectionFillMulti();
            }
            else
            {
                MessageBox.Show("Błąd formatu daty!");
            }
        }

        //odczyt i wypelnienie 
        private void SectionFill(string labelName, string dateOfAppointment)
        {
            try
            {
                double labelHeightDefault = 28;
                foreach (AppointmentDetails appointmentDetails in businessLogic.ReadListOfAppointments(dateOfAppointment))
                {
                    string labelNumber = businessLogic.SetNumberOfLabel(appointmentDetails.AppointmentTime);
                    this.Controls[labelName + labelNumber].Text = appointmentDetails.CustomerForename + " " + appointmentDetails.CustomerSurname + " " + appointmentDetails.ServiceName + " " + appointmentDetails.CustomerTelephoneNumber;
                    this.Controls[labelName + labelNumber].BackColor = Color.Coral;
                    this.Controls[labelName + labelNumber].Height = Convert.ToInt32(labelHeightDefault * Convert.ToDouble(appointmentDetails.AppointmentDuration));
                    this.Controls[labelName + labelNumber].Height = this.Controls[labelName + labelNumber].Size.Height - 2;
                    this.Controls[labelName + labelNumber].BringToFront();
                }
            }
            catch { MessageBox.Show("SectionFillError"); }
        }

        private void SectionSetToDefault(string labelName, int labelsScopeFrom, int labelsScopeTo)
        {
            double labelHeightDefault = 28;

            for (int i = labelsScopeFrom; i <= labelsScopeTo; i++)
            {
                this.Controls[labelName + i.ToString()].BackColor = Color.Beige;
                this.Controls[labelName + i.ToString()].Text = "";
                this.Controls[labelName + i.ToString()].Height = Convert.ToInt32(labelHeightDefault);
            }
        }

        private void MouseEnterOnLabel(object sender, EventArgs e)
        {            
            Label label = (Label)sender;
            labelTextBuffer = label.Text;
            label.BackColor = Color.LightBlue;

            if (label.Text == "")
            {
                label.Text = businessLogic.SetTimeByLabel(label.Name);
            }
            else
            {
                label.Text = businessLogic.SetTimeByLabel(label.Name) + " - " + labelTextBuffer;
            }
            setTimeFromLabel = businessLogic.SetTimeByLabel(label.Name);           
            setDateFromLabel = GetDateFromLabel(label.Name);
         }

        private void MouseLeaveFromLabel(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Text = labelTextBuffer;
            if (label.Text.Length < 6)
            {
                label.BackColor = Color.Beige;
                label.Text = "";
            }
            else label.BackColor = Color.Coral;
        }

        private void OnLabelClick_Click(object sender, EventArgs e)
        {
            AddOrRemoveAppointmentForm addOrRemove = new AddOrRemoveAppointmentForm(setDateFromLabel, setTimeFromLabel);
            addOrRemove.ShowDialog();
            SectionSetToDefaultMulti();
            SectionFillMulti();     // ustawic tylko 1 sekcje
        }
        private void OnLabelDoubleClick_Click(object sender, EventArgs e)
        {
     
        }
       
        private string GetDateFromLabel(string labelName)
        {
            string date = "";
            if (labelName.Contains("1_")) date = day1Label.Text;
            if (labelName.Contains("2_")) date = day2Label.Text;
            if (labelName.Contains("3_")) date = day3Label.Text;
            if (labelName.Contains("4_")) date = day4Label.Text;
            if (labelName.Contains("5_")) date = day5Label.Text;
            if (labelName.Contains("6_")) date = day6Label.Text;
            if (labelName.Contains("7_")) date = day7Label.Text;
            return date;
        }

        private void SetUserName()
        {
            UserBtn.Text = "Zalogowano : " + userStatus.GetUser();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            accountManager.LogOut();
            StartWindow startWindow = new StartWindow();
            startWindow.BringToFront();
            Close();
        }

        private void UserManageBtn_Click(object sender, EventArgs e)
        {
            UserManagerWindow userManagerWindow = new UserManagerWindow();
            userManagerWindow.ShowDialog();
        }
    }
}
