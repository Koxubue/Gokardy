using Gokardy.Controllers;
using Gokardy.DTOs.Requests;
using Gokardy.DTOs.Responses;
using Gokardy.Models;
using Gokardy.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class ZarzadzajUzytkownikService : IZarzadzajUzytkownikService
    {
        private GokardyContext context;
        public ZarzadzajUzytkownikService(GokardyContext context)
        {
            this.context = context;
        }        

        public void AktualizujDaneUzytkownika(AktualizujDaneUzytkownikaRequest request)
        {
            context.Attach(request);
            context.Entry(request).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DodajUzytkownikaDoBazy(DodajKierowceDoBazdyRequest request)
        {
            Random r = new Random();
            var numerkarty = r.Next(1, 1000);

            var kierowca = new Kierowca()
            {
                Imie = request.Imie,
                Nazwisko = request.Nazwisko,
                Wiek = request.Wiek,
                NumerKarty = "p" + numerkarty        
            };

            context.Kierowca.Add(kierowca);
            context.SaveChanges();
        }

        public void UsunUzytkownika(string rola, int Id)
        {
            if (rola == "kierowca")
            {
                var kierowca = context.Kierowca.FirstOrDefault(e => e.Id == Id);
                context.Kierowca.Remove(kierowca);
            }
            else if (rola == "pracownik")
            {
                var pracownik = context.Pracownik.FirstOrDefault(e => e.Id == Id);
                context.Pracownik.Remove(pracownik);
            }

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

        public List<UzytkownikResponse> WyswietlWszystkichUzytkownikowSystemu()
        {
            List<UzytkownikResponse> listaUzytkownikow = new List<UzytkownikResponse>();

            var pracownicy = context.Pracownik.ToList();
            foreach (var item in pracownicy)
            {
                var uzytkownik = new UzytkownikResponse()
                {
                    Id = item.Id,
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Rola = "Pracownik"
                };
                listaUzytkownikow.Add(uzytkownik);
            }

            var kierowcy = context.Kierowca.ToList();
            foreach (var item in kierowcy)
            {
                var uzytkownik = new UzytkownikResponse()
                {
                    Id = item.Id,
                    Imie = item.Imie,
                    Nazwisko = item.Nazwisko,
                    Rola = "Kierowca"
                };
                listaUzytkownikow.Add(uzytkownik);
            }

            return listaUzytkownikow;
        }
    }
}
