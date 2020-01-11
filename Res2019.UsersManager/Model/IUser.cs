namespace Res2019.UserManager.Model
{
    public interface IUser
    {
        //bool IsLoggedIn { get; set; }
        //bool IsRegisteredIn { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}