namespace Proj1.TokenAuthentication
{
    public interface ITokenManager
    {
        Token NewToken();
        bool VerifyToken(string token);
    }
}