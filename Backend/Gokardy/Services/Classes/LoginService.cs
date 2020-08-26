using Gokardy.DTOs.Responses;
using Gokardy.Encryptions;
using Gokardy.Models;
using Gokardy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class LoginService : ILoginService
    {
        private GokardyContext context;
        private IEncryption encryption;
        public LoginService(GokardyContext context, IEncryption encryption)
        {
            this.context = context;
            this.encryption = encryption;
        }
        
        public LoginModel ZalogujKierowceDoSystemu(string login, string haslo)
        {
            LoginModel model = null;
            var kierowcaZLoginem = context.Kierowca.FirstOrDefault(e => e.Login == login);
            var szukanaSol = kierowcaZLoginem.Sol;
            var szyfrowaneHaslo = szukanaSol[0] + szukanaSol[1] + encryption.SzyfrujHaslo(haslo) + szukanaSol[2] + szukanaSol[3];

            if (login == kierowcaZLoginem.Login && szyfrowaneHaslo == kierowcaZLoginem.Haslo)
            {
                model = new LoginModel()
                {
                    Login = login,
                    Haslo = szyfrowaneHaslo,
                };
            }
            return model;
        }
    }
}
