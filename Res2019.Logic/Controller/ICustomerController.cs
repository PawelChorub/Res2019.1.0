namespace Res2019.Logic.Controller
{
    public interface ICustomerController
    {
        ICustomer CreateCustomer(params string[] model);
        ICustomer GetCustomer(ICustomer _customer);
        ICustomer GetCustomer(string customer_id);
        void SaveCustomer(ICustomer customer);
    }
}