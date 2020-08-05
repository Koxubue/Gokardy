using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Sponsor
    {
        public Sponsor()
        {
            KierowcaSponsor = new HashSet<KierowcaSponsor>();
        }   

        public int Id { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<KierowcaSponsor> KierowcaSponsor { get; set; }
    }
}
