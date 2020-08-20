using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Podwozie
    {
        public Podwozie()
        {
            Gokard = new HashSet<Gokard>();
        }

        public int Id { get; set; }
        public string Producent { get; set; }
        public int Waga { get; set; }
        public double Cena { get; set; }
        public virtual ICollection<Gokard> Gokard { get; set; }
    }
}
