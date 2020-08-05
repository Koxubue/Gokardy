using Gokardy.Models;
using Gokardy.Services.Interfaces;
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
        public void AktualizujDaneUzytkownika(Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }

        public void DodajUzytkownika(Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }

        public void UsunUzytkownika(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Uzytkownik> WyswietlWszystkichUzytkownikow()
        {
            return context.Uzytkownik.ToList();
        }
    }
}
