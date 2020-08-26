using Gokardy.DTOs.Requests;
using Gokardy.DTOs.Responses;
using Gokardy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface IUzytkownikService
    { 
        // tylko zalogowany uzytkownik moze zaktualizowac swoje dane
        public void AktualizujDaneUzytkownika(AktualizujDaneUzytkownikaRequest request);

        // tylko wlasciciel moze wyswietlac wszystkich uzytkownikow
        public List<UzytkownikResponse> WyswietlWszystkichUzytkownikowSystemu();

    }
}
