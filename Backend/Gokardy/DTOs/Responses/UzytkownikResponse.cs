using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.DTOs.Responses
{
    public class UzytkownikResponse
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Rola { get; set; }
    }
}
