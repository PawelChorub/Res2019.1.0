﻿using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019
{
    public class SetValueToLabelSize : ISetValueToLabelSize
    {
        // ustawia rozmiar labela na podstawie wyboru uzytkownika;
        public string TimeToMultiplierCalculate(string valueIn)
        {
            TimeOfAppointment timeOfAppointment = new TimeOfAppointment();
            string output = timeOfAppointment.GetAppointmentTimeKey(valueIn).ToString();
            return output;
        }
    }
}
