using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.DTOs.Requests
{
    public class AktualizujDaneUzytkownikaRequest
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
    }
}
