using Gokardy.DTOs.Responses;
using Gokardy.Encryptions;
using Gokardy.Models;
using Gokardy.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class LoginKierowcaService : ILoginKierowcaService
    {
        private GokardyContext context;
        private IEncryption encryption;
        private IConfiguration config;
        public LoginKierowcaService(GokardyContext context, IEncryption encryption, IConfiguration config)
        {
            this.context = context;
            this.encryption = encryption;
            this.config = config;
        }
        
        public LoginKierowcaModel ZalogujKierowceDoSystemu(string login, string haslo)
        {
            LoginKierowcaModel model = null;
            var kierowcaZLoginem = context.Kierowca.FirstOrDefault(e => e.Login == login);
            var szukanaSol = kierowcaZLoginem.Sol;
            var szyfrowaneHaslo = szukanaSol[0] + szukanaSol[1] + encryption.SzyfrujHaslo(haslo) + szukanaSol[2] + szukanaSol[3];

            if (login == kierowcaZLoginem.Login && szyfrowaneHaslo == kierowcaZLoginem.Haslo)
            {
                model = new LoginKierowcaModel()
                {
                    Login = login,
                    Haslo = szyfrowaneHaslo,
                };
            }
            return model;
        }

        public string GenerujJSONWebToken(LoginKierowcaModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
    }
}
