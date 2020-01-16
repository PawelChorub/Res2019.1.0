using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class Date : IDate
    {
        public string Date_Id { get; set; }
        public string DateDay { get; set; }
        public string DateTime { get; set; }
        public string DateLength { get; set; }
        public string DateDuration { get; set; }
    }
}
