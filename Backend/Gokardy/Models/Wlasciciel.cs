using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Wlasciciel
    {
        public Wlasciciel()
        {
            Tor = new HashSet<Tor>();
        }
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual ICollection<Tor> Tor { get; set; }
    }
}
