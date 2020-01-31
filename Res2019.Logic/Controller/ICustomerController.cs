using System.Collections.Generic;

namespace Res2019.Logic.Controller
{
    public interface ICustomerController
    {
        ICustomer CreateCustomer(List<string> model);
        ICustomer GetCustomer(ICustomer _customer);
        ICustomer GetCustomer(string customer_id);
        void SaveCustomer(ICustomer customer);
    }
}