using BAL.Repository.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj1_api.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private readonly IUserRepo repo;
        private List<Token> tokenlist;

        public TokenManager(IUserRepo repo)
        {
            this.repo = repo;
            tokenlist = new List<Token>();
        }
        public bool Authenticate(User us)
        {
            if (us != null)
            {
                var data = repo.Login(us);
                if (data != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpireDate = DateTime.Now.AddMinutes(30)
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
