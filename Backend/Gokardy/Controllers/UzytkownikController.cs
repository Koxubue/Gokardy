using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gokardy.Models;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gokardy.Controllers
{
    [Route("api/uzytkownik")]
    [ApiController]
    public class UzytkownikController : ControllerBase
    {
        private IZarzadzajUzytkownikService service;
        public UzytkownikController(IZarzadzajUzytkownikService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult WyswietlWszystkichUzytkownikowSystemu()
        {
            var result = service.WyswietlWszystkichUzytkownikowSystemu();
            return Ok(result);
        }
    }
}
