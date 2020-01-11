using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019
{
    public class TimeFromLabel : ITimeFromLabel
    {
        public string GetTimeFromLabel(string labelName)
        {
            HourOfAppointment hoa = new HourOfAppointment();
                      
            string[] namePartial = labelName.Split('_');
            int.TryParse(namePartial[1], out int output);

            return hoa.GetAppointmentHourValue(output);
        }

        //public string GetTimeFromLabelOLD(string labelName)
        //{
        //    string x = "1";
        //    string t = "";
        //    bool y = labelName.Contains("_" + x);
        //    string[] a = labelName.Split('_');
        //    string a1 = a[1];
        //    if (labelName.Contains("_1")) t = "8:00";
        //    if (labelName.Contains("_2")) t = "8:30";
        //    if (labelName.Contains("_3")) t = "9:00";
        //    if (labelName.Contains("_4")) t = "9:30";
        //    if (labelName.Contains("_5")) t = "10:00";
        //    if (labelName.Contains("_6")) t = "10:30";
        //    if (labelName.Contains("_7")) t = "11:00";
        //    if (labelName.Contains("_8")) t = "11:30";
        //    if (labelName.Contains("_9")) t = "12:00";
        //    if (labelName.Contains("_10")) t = "12:30";
        //    if (labelName.Contains("_11")) t = "13:00";
        //    if (labelName.Contains("_12")) t = "13:30";
        //    if (labelName.Contains("_13")) t = "14:00";
        //    if (labelName.Contains("_14")) t = "14:30";
        //    if (labelName.Contains("_15")) t = "15:00";
        //    if (labelName.Contains("_16")) t = "15:30";
        //    if (labelName.Contains("_17")) t = "16:00";
        //    if (labelName.Contains("_18")) t = "16:30";
        //    if (labelName.Contains("_19")) t = "17:00";
        //    if (labelName.Contains("_20")) t = "17:30";
        //    if (labelName.Contains("_21")) t = "18:00";
        //    if (labelName.Contains("_22")) t = "18:30";
        //    return t;
        //}

    }
}
