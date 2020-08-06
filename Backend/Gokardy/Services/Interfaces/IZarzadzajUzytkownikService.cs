using Gokardy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface IZarzadzajUzytkownikService
    {
        public void DodajUzytkownika(Uzytkownik uzytkownik);
        public void UsunUzytkownika(int Id);
        public void AktualizujDaneUzytkownika(Uzytkownik uzytkownik);
        public List<Uzytkownik> WyswietlWszystkichUzytkownikow();
    }
}
