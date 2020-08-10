using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gokardy.Controllers
{
    [Route("api/tor")]
    [ApiController]
    public class TorController : ControllerBase
    {
        private IZarzadzajTorService service;
        public TorController(IZarzadzajTorService service)
        {
            this.service = service;
        }

        [HttpGet("{nazwaMiasta}")]
        [Route("/miasto")]
        public IActionResult WyszukajTor(string nazwaMiasta)
        {
            service.WyszukajTorWDanymMiesice(nazwaMiasta);
            return Ok();
        }

        [HttpGet]
        [Route("/stawka")]
        public IActionResult WyszukajTorStawka()
        {
            service.WyszukajTorStawka();
            return Ok();
        }

    }
}
