namespace Res2019
{
    public interface ICustomer
    {
        string CustomerId { get; set; }
        string Email { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        string Telephone { get; set; }
    }
}