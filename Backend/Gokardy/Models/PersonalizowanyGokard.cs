using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class PersonalizowanyGokard
    {
        public int Id { get; set; }
        public int KierowcaId { get; set; }
        public int GokardId { get; set; }
        public virtual Kierowca Kierowca { get; set; }
        public virtual Gokard Gokard { get; set; }
    }
}
