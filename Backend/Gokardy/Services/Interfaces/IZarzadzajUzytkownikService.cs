using Gokardy.DTOs.Requests;
using Gokardy.DTOs.Responses;
using Gokardy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface IZarzadzajUzytkownikService
    {
        // rejestracja jest tylko dla kierowcow (klientow)   
        public void DodajUzytkownikaDoBazy(DodajKierowceDoBazdyRequest request);

        // usunac uzytkownika z systemu moze tylko wlasciciel
        public void UsunUzytkownika(string rola, int Id);
        // tylko zalogowany uzytkownik moze zaktualizowac swoje dane
        public void AktualizujDaneUzytkownika(AktualizujDaneUzytkownikaRequest request);

        // tylko wlasciciel moze wyswietlac wszystkich uzytkownikow
        public List<UzytkownikResponse> WyswietlWszystkichUzytkownikowSystemu();
    }
}
