using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.DTOs.Requests
{
    public class PersonalizujGokardaRequest
    {
        public string NazwaPersonalizowanegoGokarda { get; set; }
        public string NazwaProducentaPodwozia { get; set; }
        public string NazwaProducentaNadwozia { get; set; }
        public string NazwaProducentaSilnika { get; set; }
        public string NazwaToru { get; set; }
    }
}
