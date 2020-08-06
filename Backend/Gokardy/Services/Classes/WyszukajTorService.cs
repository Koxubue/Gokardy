using Gokardy.Models;
using Gokardy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class WyszukajTorService : IWyszukajTorService
    {
        private GokardyContext context;
        public WyszukajTorService(GokardyContext context)
        {
            this.context = context;
        }
        public List<Tor> WyszukajTorWDanymMiesice(string nazwaMiasta)
        {   
            var w = context.Tor
                .Where(e => e.Adres.Miasto == nazwaMiasta)
                .Select(x => new { x.Nazwa, x.Adres.Miasto })
                .ToList();

            return context.Tor.Include(e => e.Adres).Where(e => e.Adres.Miasto == nazwaMiasta).ToList();
        }
    }
}
