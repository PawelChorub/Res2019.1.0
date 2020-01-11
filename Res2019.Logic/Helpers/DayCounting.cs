using Ninject;
using Res2019.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019
{
    public class DayCounting : IDayCounting
    {
        IKernel kernel = new StandardKernel(new DI_Container());
        private IDateFormatCheck dateFormatCheck;

        public DayCounting()
        {
            dateFormatCheck = kernel.Get<IDateFormatCheck>();
        }
        public string SetPreviousOrNextDay(string dateIn, int dayToMove)
        {
            if (dateFormatCheck.Check_YYYY_MM_DD_Format(dateIn))
            {
                string dateOut;
                DateTime dateTimeIn = DateTime.Parse(dateIn);
                DateTime dateTimeOut = dateTimeIn.AddDays(dayToMove);
                return dateOut = dateTimeOut.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Zły format daty!, Wymagany format : YYYY-MM-DD");
                return SetCurrentDate();
            }
        }
        public string SetCurrentDate()
        {
            string currentDay = DateTime.Now.Date.ToString("yyyy-MM-dd");
            return currentDay;
        }
    }
}
