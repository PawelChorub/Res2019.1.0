using System.Collections.Generic;

namespace Res2019.UserManager
{
    public interface IAccountManager
    {
        void CreateUserAccount(string login, string password);
        void LogOut();
        void RemoveUserAccount(string login);
        List<string> ReturnAllUsers();
        void VerifyUserAccount(string login, string password);
    }
}