using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Adres
    {
        public int IdAdres { get; set; }
        public string Panstwo { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }

        public virtual Tor Tor { get; set; }
    }
}
