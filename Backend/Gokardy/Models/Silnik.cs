using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Silnik
    {
        public Silnik()
        {
            Gokard = new HashSet<Gokard>();
        }

        public int Id { get; set; }
        public int Moc { get; set; }
        public int Pojemnosc { get; set; }
        public string Producent { get; set; }

        public virtual ICollection<Gokard> Gokard { get; set; }
    }
}
