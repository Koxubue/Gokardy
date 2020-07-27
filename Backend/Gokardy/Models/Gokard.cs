using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Gokard
    {
        public Gokard()
        {
            Przejazd = new HashSet<Przejazd>();
        }

        public int IdGokard { get; set; }
        public string Nazwa { get; set; }
        public int Waga { get; set; }
        public int IdSilnik { get; set; }
        public int IdPodwozie { get; set; }
        public int IdNadwozie { get; set; }
        public int IdTor { get; set; }

        public virtual Silnik IdSilnikNavigation { get; set; }
        public virtual Nadwozie IdNadwozieNavigation { get; set; }
        public virtual Podwozie IdPodwozieNavigation { get; set; }
        public virtual Tor IdTorNavigation { get; set; }
        public virtual ICollection<Przejazd> Przejazd { get; set; }
    }
}
