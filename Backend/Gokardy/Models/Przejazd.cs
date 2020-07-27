using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Przejazd
    {
        public int IdPrzejazd { get; set; }
        public DateTime Czas { get; set; }
        public int IdGokard { get; set; }
        public int IdTor { get; set; }
        public int IdKierowca { get; set; }

        public virtual Gokard IdGokardNavigation { get; set; }
        public virtual Tor IdTorNavigation { get; set; }
        public virtual Kierowca IdKierowcaNavigation { get; set; }
    }
}
