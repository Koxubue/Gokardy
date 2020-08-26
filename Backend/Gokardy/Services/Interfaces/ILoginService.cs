using Gokardy.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface ILoginService
    {
        public LoginModel ZalogujKierowceDoSystemu(string login, string haslo);
    }
}
