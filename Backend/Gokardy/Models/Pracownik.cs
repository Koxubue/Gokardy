using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Stanowisko { get; set; }
        public double Wynagrodzenie { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Sol { get; set; }
        public int TorId { get; set; }

        public virtual Tor Tor { get; set; }
    }
}
