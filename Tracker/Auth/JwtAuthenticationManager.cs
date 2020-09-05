using DAL;
using Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Tracker.Auth
{
    public class JwtAuthenticationManager : IAuthenticationManager
    {
        private readonly ICRUDRepo<UCredential> _repository;
        private readonly IOptions<SettingsData> _settings;
        private readonly string _key;
        private readonly Dictionary<string, string> _roles;

        public JwtAuthenticationManager(ICRUDRepo<UCredential> repository, IOptions<SettingsData> settingsData)
        {
            _repository = repository;
            _settings = settingsData;
            _key = _settings.Value.AuthenticationKey;
            //_key = "This is a private key for test app";
            _roles = new Dictionary<string, string> { { "john", "Admin" }, { "george", "User" }, { "thomas", "User" }  };
        }


        public string Authenticate(string username, string password)
        {
            var uCred = _repository.GetRowByKey(username);
            
            if (uCred == null || uCred.Password != password) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, uCred.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
