using Gokardy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface IZarzadzajTorService
    {
        public List<Tor> WyszukajTorWDanymMiesice(string nazwaMiasta);

        public List<Tor> WyszukajTorStawka();
    }
}
