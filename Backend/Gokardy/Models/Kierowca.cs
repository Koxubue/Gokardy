using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Kierowca
    {
        public Kierowca()
        {
            Przejazd = new HashSet<Przejazd>();
            KierowcaSponsor = new HashSet<KierowcaSponsor>();
            Sprzet = new HashSet<Sprzet>();
        }

        public int IdKierowca { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string NumerKarty { get; set; }
        public int IdUzytkownik { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
        public virtual ICollection<Przejazd> Przejazd { get; set; }
        public virtual ICollection<KierowcaSponsor> KierowcaSponsor { get; set; }
        public virtual ICollection<Sprzet> Sprzet { get; set; }
    }
}
