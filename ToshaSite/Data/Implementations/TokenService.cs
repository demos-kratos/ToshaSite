using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToshaSite.Data.Implementations
{
    public class TokenService : ITokenService
    {
        class TokenContainer
        {
            public string Token { get; set; }
            public DateTime ValidBy { get; set; }
        }

        private readonly List<TokenContainer> Tokens = new List<TokenContainer>();

        public DateTime? CheckToken(string token)
        {
            var tc = Tokens.FirstOrDefault(x => x.Token == token);
            if(tc != null && tc.ValidBy < DateTime.Now)
            {
                Tokens.Remove(tc);
                return null;
            }
            return tc?.ValidBy;
        }

        public string GetToken()
        {
            var r = new Random();
            var bytes = new byte[32];
            r.NextBytes(bytes);
            var tc = new TokenContainer
            {
                Token = Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", ""),
                ValidBy = DateTime.Now.AddMinutes(30)
            };
            Tokens.Add(tc);
            return tc.Token;
        }
    }
}
