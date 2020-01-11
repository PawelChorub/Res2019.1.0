namespace Res2019.UserManager
{
    public interface ISCryptHashing
    {
        string Encode(string plainText);
        bool Verify(string plainText, string hashText);
    }
}