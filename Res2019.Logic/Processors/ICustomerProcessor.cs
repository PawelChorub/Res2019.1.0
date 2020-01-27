namespace Res2019.Logic.Processors
{
    public interface ICustomerProcessor
    {
        ICustomer CreateCustomer(params string[] model);
    }
}