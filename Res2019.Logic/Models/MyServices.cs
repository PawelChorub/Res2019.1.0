using Res2019.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Models
{
    public class MyServices : IServiceLibrary, IMyServices
    {
        public string ServiceName { get; set; }
        // cena itd
    }
}
