using Models.Models;

namespace Proj1_api.TokenAuthentication
{
    public interface ITokenManager
    {
        bool Authenticate(User us);
        Token NewToken();
        bool VerifyToken(string token);
    }
}