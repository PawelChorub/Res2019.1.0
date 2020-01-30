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
        public string Day { get; set; }
        public string Time { get; set; }
        public string Length { get; set; }
        public string Duration { get; set; }
    }
}
