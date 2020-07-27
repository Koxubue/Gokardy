using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Sprzet
    {
        public int IdSprzet { get; set; }
        public string Nazwa { get; set; }
        public double Koszt { get; set; }
        public int IdKierowca { get; set; }  
        
        public virtual Kierowca Kierowca { get; set; }
    }
}
