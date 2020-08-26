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
    public class UzytkownikService : IUzytkownikService
    {
        private GokardyContext context;
        public UzytkownikService(GokardyContext context)
        {
            this.context = context;
        }        

        public void AktualizujDaneUzytkownika(AktualizujDaneUzytkownikaRequest request)
        {
            context.Attach(request);
            context.Entry(request).State = EntityState.Modified;
            context.SaveChanges();
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
