using Gokardy.DTOs.Requests;
using Gokardy.DTOs.Responses;
using Gokardy.Encryptions;
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
        private IEncryption encryption;
        public ZarzadzajKierowcaService(GokardyContext context, IEncryption encryption)
        {
            this.context = context;
            this.encryption = encryption;
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

        public void DodajKierowceDoBazy(DodajKierowceDoBazdyRequest request)
        {
            var numerkarty = encryption.LosowanieLiczby().Next(1, 1000);
            var wygenerowanaSol = encryption.GenerowanieSoli();
            var kierowca = new Kierowca()
            {
                Imie = request.Imie,
                Nazwisko = request.Nazwisko,
                Wiek = request.Wiek,
                NumerKarty = "p" + numerkarty,
                Sol = wygenerowanaSol,
                Login = request.Login,
                Haslo = wygenerowanaSol[0] + wygenerowanaSol[1] + encryption.SzyfrujHaslo(request.Haslo) + wygenerowanaSol[2] + wygenerowanaSol[3]
            };

            context.Kierowca.Add(kierowca);
            context.SaveChanges();
        }
        public void UsunKierowce(int Id)
        {
            var pracownik = context.Pracownik.FirstOrDefault(e => e.Id == Id);
            context.Pracownik.Remove(pracownik);
            context.SaveChanges();
        }

        public List<KierowcaResponse> WyswietlWszystkichKierowcowSystemu()
        {
            List<string> listaSponsorow = new List<string>();
            List<KierowcaResponse> listaKierowcow = new List<KierowcaResponse>();

            var result = context.Kierowca.ToList();
            foreach (var item in result)
            {
                var sponsorzy = context.KierowcaSponsor.Where(e => e.KierowcaId == item.Id).Select(e => e.Sponsor.Nazwa).ToList();
                var kierowca = new KierowcaResponse()
                {
                    Id = item.Id,
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Wiek = item.Wiek,
                    NumerKarty = item.NumerKarty,
                    Sponsorzy = sponsorzy
                };
                listaKierowcow.Add(kierowca);
            }
            return listaKierowcow;
        }

    }
}
