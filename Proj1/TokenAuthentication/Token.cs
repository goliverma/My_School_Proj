using System;

namespace Proj1.TokenAuthentication
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
