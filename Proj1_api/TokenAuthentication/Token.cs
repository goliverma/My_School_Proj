using System;

namespace Proj1_api.TokenAuthentication
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
