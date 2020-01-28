using System.Collections.Generic;
using Res2019.Logic.Models;

namespace Res2019.Logic.Controller
{
    public interface IDateController
    {
        IDate CreateDate(params string[] model);
        void DeleteDate(string date_id);
        IDate GetDate(string date_id);
        IDate GetDate(string day, string time);
        List<string> GetListOfDate_id(string day);
        void SaveDate(IDate date);
        void UpdateDate(IDate date, IAppointment appointment);
    }
}