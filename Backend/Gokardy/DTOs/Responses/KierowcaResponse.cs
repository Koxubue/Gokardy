using Gokardy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.DTOs.Responses
{
    public class KierowcaResponse
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string NumerKarty { get; set; }
        public List<string> Sponsorzy { get; set; }
    }
}
