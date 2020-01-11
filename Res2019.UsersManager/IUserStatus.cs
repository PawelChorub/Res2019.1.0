namespace Res2019.UserManager
{
    public interface IUserStatus
    {
        bool ReturnStatus();
        string ReturnUser();
        void SetStatus(bool isLogged, string userName);
    }
}