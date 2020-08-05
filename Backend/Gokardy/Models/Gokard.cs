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

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Waga { get; set; }
        public int SilnikId { get; set; }
        public int PodwozieId { get; set; }
        public int NadwozieId { get; set; }
        public int TorId { get; set; }

        public virtual Silnik Silnik { get; set; }
        public virtual Nadwozie Nadwozie { get; set; }
        public virtual Podwozie Podwozie { get; set; }
        public virtual Tor Tor { get; set; }
        public virtual ICollection<Przejazd> Przejazd { get; set; }
    }
}
