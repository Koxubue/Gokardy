using Gokardy.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface ILoginKierowcaService
    {
        public LoginKierowcaModel ZalogujKierowceDoSystemu(string login, string haslo);
        public string GenerujJSONWebToken(LoginKierowcaModel model);
    }
}
