using Res2019.Logic.Models;
using System.Collections.Generic;

namespace Res2019.Logic
{
    public interface IBusinessLogic
    {
        void AppointmentDetails(string date, string time, string length, string duration, string fname, string sname, string tel, string service);
        void ModifyAppointmentDetails(string date, string time, string length, string duration, string fname, string sname, string tel, string service, string existAppDuration);
        void DeleteAppointment(string date, string time);
        IAppointmentDetails ReadSingleAppointment(string date, string time);
        List<IAppointmentDetails> ReadListOfAppointments(string date);

        string DateSet(string date, int manipulation);
        string CurrentDateSet();

        bool DateFormat(string date);

        string SetTimeByLabel(string _labelName);

        string SetNumberOfLabel(string _timeOfAppointment);

        string LabelSizeMultiplier(string _valueIn);
    }
}