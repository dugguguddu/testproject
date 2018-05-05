using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SalesMarket.Serv
{
    public sealed class JwtToken
    {
        private JwtSecurityToken token;
        internal JwtToken(JwtSecurityToken _token)
        {
            token = _token;
        }

        public DateTime ValidTo => token.ValidTo;
        public string Value => new JwtSecurityTokenHandler().WriteToken(token);
    }
}
