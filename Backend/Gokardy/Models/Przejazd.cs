using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Przejazd
    {
        public int Id { get; set; }
        public TimeSpan Czas { get; set; }
        public DateTime DataPrzejazdu { get; set; }
        public int GokardId { get; set; }
        public int TorId { get; set; }
        public int KierowcaId { get; set; }

        public virtual Gokard Gokard { get; set; }
        public virtual Tor Tor { get; set; }
        public virtual Kierowca Kierowca { get; set; }
    }
}
