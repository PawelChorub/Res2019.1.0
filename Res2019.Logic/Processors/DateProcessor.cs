using Ninject;
using Res2019.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Processors
{
    public class DateProcessor : IDateProcessor
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());

        public IDate CreateDate(params string[] model)
        {
            IDate date = kernel.Get<IDate>();
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

    }
}
