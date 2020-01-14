using Res2019.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019
{
    public class Customer : IForenameLibrary, ISurnameLibrary, ITelephoneNumberLibrary, IEmailLibrary, ICustomer
    {
        public string CustomerId { get; set; }
        public string CustomerForename { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerTelephoneNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
}
