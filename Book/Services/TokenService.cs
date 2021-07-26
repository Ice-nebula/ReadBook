using Book.Domain;
using Book.Models;
using Book.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Book.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(UserModel userModel)
        {
            var jwt = _configuration.GetSection("JWTSettings");
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,userModel.UserName),
                new Claim(ClaimTypes.NameIdentifier,userModel.Id)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["securityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(jwt["validIssuer"], jwt["validAudience"], claims,
    expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
