using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj1.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private List<Token> tokenlist;
        public TokenManager()
        {
            tokenlist = new List<Token>();
        }

        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddSeconds(300)
            };
            tokenlist.Add(token);
            return token;
        }
        public bool VerifyToken(string token)
        {
            if (tokenlist.Any(x => x.Value == token && x.ExpireDate > DateTime.Now))
            {
                return true;
            }
            return false;
        }
    }
}
