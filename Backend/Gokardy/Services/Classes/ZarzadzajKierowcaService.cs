using Gokardy.DTOs.Responses;
using Gokardy.Models;
using Gokardy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class ZarzadzajKierowcaService : IZarzadajKierowcaService
    {
        private GokardyContext context;
        public ZarzadzajKierowcaService(GokardyContext context)
        {
            this.context = context;
        }

        public List<KierowcaBezSponsoraResponse> KierowcaBezSponsora()
        {
            List<KierowcaBezSponsoraResponse> list = new List<KierowcaBezSponsoraResponse>();
            var result = context.KierowcaSponsor.Where(e => e.KierowcaId != e.Kierowca.Id).Select(e => new
            {
                e.Kierowca.Id,
                e.Kierowca.Imie,
                e.Kierowca.Nazwisko
            }).ToList();

            KierowcaBezSponsoraResponse response = new KierowcaBezSponsoraResponse();
            foreach (var item in result)
            {
                response.Id = item.Id;
                response.Imie = item.Imie;
                response.Nazwisko = item.Nazwisko;

                list.Add(response);
            }
            return list;
        }
    }
}
