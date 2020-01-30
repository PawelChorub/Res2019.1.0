using Ninject;
using Res2019.Logic.Models;
using Res2019.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Res2019.Logic.Controller
{
    public class DateController : IDateController
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());
        private static IMsSqlDataAccess msSqlDataAccess = MsSqlManager.CreateMsSqlDataAccess();
        private string query = "";
        IDate date;
        public DateController()
        {
            date = kernel.Get<IDate>();
        }

        public IDate CreateDate(params string[] model)
        {
            if (model.Length > 0)
            {
                date.Date_Id = model[0];
                date.Day = model[1];
                date.Time = model[2];
                date.Length = model[3];
                date.Duration = model[4];
            }
            return date;
        }
        public void SaveDate(IDate date)
        {
            query = string.Format("INSERT INTO date (day, time, length, duration) VALUES ('{0}','{1}','{2}', '{3}')",
                 date.Day,
                 date.Time,
                 date.Length,
                 date.Duration);

            msSqlDataAccess.SaveData(query);
        }

        public List<string> GetListOfDate_id(string day)
        {
            var modelProperty = date.GetType().GetProperty("Date_Id").Name;
            query = string.Format("SELECT * FROM date WHERE day = '{0}'", day);
            var receivedData = msSqlDataAccess.GetSingleColumnDataList(query, modelProperty);
            return receivedData;
        }

        public IDate GetDate(string date_id)
        {
            query = string.Format("SELECT * FROM date WHERE date_id = '{0}'", date_id);
            var receivedData = msSqlDataAccess.GetDataList(query, date).ToArray();

            date = CreateDate(receivedData);
            return date;
        }

        public IDate GetDate(string day, string time)
        {
            query = string.Format("SELECT * FROM date WHERE day = '{0}' AND time = '{1}'", day, time);
            var receivedData = msSqlDataAccess.GetDataList(query, date).ToArray();

            date = CreateDate(receivedData);
            return date;
        }
        public void UpdateDate(IDate date, IAppointment appointment)
        {
            query = string.Format("UPDATE date SET day = '{0}'," +
                "time = '{1}', length = '{2}', duration = '{3}' WHERE date_id = '{4}'",
                date.Day,
                date.Time,
                appointment.AppointmentLength,
                appointment.AppointmentDuration,
                date.Date_Id);
            msSqlDataAccess.SaveData(query);
        }

        public void DeleteDate(string date_id)
        {
            query = string.Format("DELETE FROM date WHERE date_id = '{0}'", date_id);
            msSqlDataAccess.SaveData(query);
        }
    }
}
