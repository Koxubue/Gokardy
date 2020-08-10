using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gokardy.Controllers
{
    [Route("api/kierowca")]
    [ApiController]
    public class KierowcaController : ControllerBase
    {
        private IZarzadajKierowcaService service;
        public KierowcaController(IZarzadajKierowcaService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("/bezSponsora")]
        public IActionResult KierowcaBezSponsora()
        {
            service.KierowcaBezSponsora();
            return Ok();
        }
    }
}
