using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Nadwozie
    {
        public Nadwozie()
        {
            Gokard = new HashSet<Gokard>();
        }

        public int Id { get; set; }
        public string Producent { get; set; }

        public virtual ICollection<Gokard> Gokard { get; set; }
    }
}
