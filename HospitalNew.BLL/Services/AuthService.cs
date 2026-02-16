using HospitalNew.DAL.Interfaces;
using HospitalNew.BLL.Interfaces;
using HospitalNew.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace HospitalNew.BLL.Services
{
    
    public class AuthService : IAuthSerice
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var jwtSection = _configuration.GetSection("JWT");
            var secret = jwtSection["Secret"];

            if (string.IsNullOrEmpty(secret))
                throw new Exception("JWT Secret is missing");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret)
            );

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.GivenName, user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
