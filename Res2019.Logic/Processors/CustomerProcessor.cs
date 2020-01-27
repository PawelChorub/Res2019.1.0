using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res2019.Logic.Processors
{
    public class CustomerProcessor : ICustomerProcessor
    {
        readonly IKernel kernel = new StandardKernel(new DI_Container());

        public ICustomer CreateCustomer(params string[] model)
        {
            ICustomer customer = kernel.Get<ICustomer>();

            customer.Customer_Id = model[0];
            customer.Forename = model[1];
            customer.Surname = model[2];
            customer.Telephone = model[3];
            customer.Email = model[4];

            return customer;
        }

    }
}
