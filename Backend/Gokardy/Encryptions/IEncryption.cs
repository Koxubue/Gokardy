using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Encryptions
{
    public interface IEncryption
    {
        public string SzyfrujHaslo(string haslo);
        public string GenerowanieSoli();
        public Random LosowanieLiczby();
    }
}
