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
        public void AktualizujDaneUzytkownika(Uzytkownik uzytkownik)
        {
            context.Attach(uzytkownik);
            context.Entry(uzytkownik).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DodajUzytkownika(Uzytkownik uzytkownik)
        {
            context.Uzytkownik.Add(uzytkownik);
            context.SaveChanges();
        }

        public void UsunUzytkownika(int Id)
        {
            var uzytkownik = context.Uzytkownik.First(e => e.Id == Id);
            context.Uzytkownik.Remove(uzytkownik);
            context.SaveChanges();
        }

        public List<Uzytkownik> WyswietlWszystkichUzytkownikow()
        {
            return context.Uzytkownik.ToList();
        }
    }
}
