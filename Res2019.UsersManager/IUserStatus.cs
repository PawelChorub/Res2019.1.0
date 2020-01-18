namespace Res2019.UserManager
{
    public interface IUserStatus
    {
        bool GetUserStatus();
        string GetUser();
        void SetStatus(bool isLogged, string userName);
    }
}