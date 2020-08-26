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
            PersonalizowanyGokard = new HashSet<PersonalizowanyGokard>();
        }

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string NumerKarty { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Sol { get; set; }

        public virtual ICollection<Przejazd> Przejazd { get; set; }
        public virtual ICollection<KierowcaSponsor> KierowcaSponsor { get; set; }
        public virtual ICollection<Sprzet> Sprzet { get; set; }
        public virtual ICollection<PersonalizowanyGokard> PersonalizowanyGokard { get; set; }
    }
}
