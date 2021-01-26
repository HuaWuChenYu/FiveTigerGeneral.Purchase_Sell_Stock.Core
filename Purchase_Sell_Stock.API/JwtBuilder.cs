using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Purchase_Sell_Stock.Model.Login;

namespace Purchase_Sell_Stock.API
{
    public class JwtBuilder
    {
        private readonly TokenManagement _tokenManagement;
        public JwtBuilder(IOptions<TokenManagement> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }
        public string GetJwt(Users user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserId.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
