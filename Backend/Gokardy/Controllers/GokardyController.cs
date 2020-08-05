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
    [Route("api/gokardy")]
    [ApiController]
    public class GokardyController : ControllerBase
    {
        private IUzytkownikService service;
        public GokardyController(IUzytkownikService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult WyswietlWszystkichUzytkownikow()
        {
            var result = service.WyswietlWszystkichUzytkownikow();
            return Ok(result);
        }
    }
}
