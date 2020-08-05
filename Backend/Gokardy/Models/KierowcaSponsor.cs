using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class KierowcaSponsor
    {
        public int KierowcaId { get; set; }
        public int SponsorId { get; set; }

        public virtual Kierowca Kierowca { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}
