using Gokardy.DTOs.Requests;
using Gokardy.Models;
using Gokardy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class ZarzadzajGokardService : IZarzadzajGokardService
    {
        private GokardyContext context;
        public ZarzadzajGokardService(GokardyContext context)
        {
            this.context = context;
        }
        public void PersonalizujGokard(PersonalizujGokardaRequest request, int Id)
        {
            var silnik = context.Silnik.Where(e => e.Producent == request.NazwaProducentaSilnika).Select(x => new { x.Id, x.Cena, x.Waga}).FirstOrDefault();
            var nadwozie = context.Nadwozie.Where(e => e.Producent == request.NazwaProducentaNadwozia).Select(x => new { x.Id, x.Cena, x.Waga }).FirstOrDefault();
            var podwozie = context.Podwozie.Where(e => e.Producent == request.NazwaProducentaPodwozia).Select(x => new { x.Id, x.Cena, x.Waga }).FirstOrDefault();
            var torId = context.Tor.Where(e => e.Nazwa == request.NazwaToru).Select(x => x.Id).FirstOrDefault();

            var nowyGokard = new Gokard()
            {
                Nazwa = request.NazwaPersonalizowanegoGokarda,
                SilnikId = silnik.Id,
                NadwozieId = nadwozie.Id,
                PodwozieId = podwozie.Id,
                TorId = torId,
                Waga = silnik.Waga + nadwozie.Waga + podwozie.Waga,
                Cena = silnik.Cena + nadwozie.Cena + podwozie.Cena
            };
            context.Gokard.Add(nowyGokard);
            context.SaveChanges();

            var gokard = context.Gokard.Select(x => new { x.Id, x.Cena, x.Waga }).LastOrDefault();

            var personalizowanyGokard = new PersonalizowanyGokard()
            {
                GokardId = gokard.Id,
                KierowcaId = Id
            };
            context.PersonalizowanyGokard.Add(personalizowanyGokard);
            context.SaveChanges();
        }
    }
}
