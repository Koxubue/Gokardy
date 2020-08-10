using Gokardy.Models;
using Gokardy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class ZarzadzajTorService : IZarzadzajTorService
    {
        private GokardyContext context;
        public ZarzadzajTorService(GokardyContext context)
        {
            this.context = context;
        }

        public List<Tor> WyszukajTorStawka()
        {
            var ceny = context.Tor.Select(e => e.StawkaGodzinowa).ToList();
            double sumaCen = 0;
            foreach (var item in ceny)
            {
                sumaCen += item;
            }
            return context.Tor.Where(e => e.StawkaGodzinowa <= sumaCen).ToList();
        }

        public List<Tor> WyszukajTorWDanymMiesice(string nazwaMiasta)
        {   
            //var w = context.Tor
            //    .Where(e => e.Adres.Miasto == nazwaMiasta)
            //    .Select(x => new { x.Nazwa, x.Adres.Miasto })
            //    .ToList();

            return context.Tor.Include(e => e.Adres).Where(e => e.Adres.Miasto == nazwaMiasta).ToList();
        }
    }
}
