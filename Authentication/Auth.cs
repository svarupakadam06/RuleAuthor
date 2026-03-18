using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.DTOs;
using FraudMonitoringSystem.Models.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Claims;
using System.Text;
using System.Text;


namespace FraudMonitoringSystem.Authentication
{
    public class Auth : IAuth
    {
        private readonly WebContext _context;
        private readonly IConfiguration _configuration;
        public Auth(WebContext context,
                    IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _context.Registrations
                .FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
                throw new Exception("Invalid Email");
            if (user.Password != dto.Password)
                throw new Exception("Invalid Password");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email), 
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("RegistrationId", user.RegistrationId.ToString())
           };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
