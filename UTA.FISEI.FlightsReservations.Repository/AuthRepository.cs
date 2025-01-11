using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UTA.FISEI.FlightsReservations.Domain;
using UTA.FISEI.FlightsReservations.Interfaces;

namespace UTA.FISEI.FlightsReservations.Repository
{
    public class AuthRepository : IAuth
    {
        UserRepository _userRepository = new UserRepository();
        private readonly string _jwtSecretKey;
        public AuthRepository()
        {
            _jwtSecretKey = ConfigurationManager.AppSettings["JwtSecret"];
        }
        public string login(string email, string password)
        {
            User user = _userRepository.getUser(email);            
                if (user == null || !VerifyPassword(password, user.password))
                {
                    throw new UnauthorizedAccessException("Credenciales inválidas");
                }
            var claims = new[]
            {
                new Claim("uid", user.userId.ToString()),
                new Claim("email", user.email),
                new Claim("role", user.roleId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: creds
                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
