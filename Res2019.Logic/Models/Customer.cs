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
        public string Customer_Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
