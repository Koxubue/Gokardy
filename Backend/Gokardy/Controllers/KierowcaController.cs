using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gokardy.DTOs.Requests;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gokardy.Controllers
{
    [Route("api/kierowca")]
    [ApiController]
    public class KierowcaController : ControllerBase
    {
        private IZarzadajKierowcaService serviceKierowca;
        private IZarzadzajGokardService serviceGokard;
        public KierowcaController(IZarzadajKierowcaService serviceKierowca, IZarzadzajGokardService serviceGokard)
        {
            this.serviceKierowca = serviceKierowca;
            this.serviceGokard = serviceGokard;
        }

        [HttpGet]
        [Route("/bezSponsora")]
        public IActionResult KierowcaBezSponsora()
        {
            serviceKierowca.KierowcaBezSponsora();
            return Ok();
        }

        [HttpPost]
        [Route("/personalizuj")]
        public IActionResult PersonalizacjaGokarda(PersonalizujGokardaRequest request, int Id)
        {
            serviceGokard.PersonalizujGokard(request, Id);
            return Ok();
        }
    }
}
