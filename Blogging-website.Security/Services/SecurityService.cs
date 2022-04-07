using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Blogging_website.Security.IServices;
using Blogging_website.Security.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blogging_website.Security.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly IAccountLoginService _accountLogin;
        
        public IConfiguration Configuration { get; }
        
        public SecurityService(IConfiguration configuration, IAccountLoginService accountLogin)
        {
            Configuration = configuration;
            _accountLogin = accountLogin;
        }
        public JwtToken GenerateJwtToken(string email, string password)
        {
            var accountLogin = _accountLogin.GetAccountLogin(email);
            //Validate User - Generate
            if (Authenticate(password, accountLogin))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, accountLogin.LoginId.ToString()),
                        new Claim(ClaimTypes.Email, accountLogin.Email)
                    },
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);
                return new JwtToken
                {
                    Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Ok"
                };
            }
            return new JwtToken
            {
                Message = "User or Password not correct"
            };
        }

        public bool Authenticate(string plainPassword, AccountLogin login)
        {
            if (login == null || login.HashedPassword.Length <= 0 || login.Salt.Length <= 0) 
                return false;

            var hashedPasswordFromPlain = HashPassword(plainPassword, login.Salt);
            return login.HashedPassword.Equals(hashedPasswordFromPlain);
        }

        public string HashPassword(string plainPassword, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }

        public byte[] GenerateSalt()
        {
            //Make new Salt
            var salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}