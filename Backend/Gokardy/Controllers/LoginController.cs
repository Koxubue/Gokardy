using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gokardy.DTOs.Responses;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Gokardy.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginKierowcaService service;        
        public LoginController(ILoginKierowcaService service)
        { 
            this.service = service;
        }

        [HttpGet]
        public IActionResult Login(string username, string pass)
        {         
            IActionResult response = Unauthorized();
            var user = service.ZalogujKierowceDoSystemu(username, pass);

            if (user != null)
            {
                var tokenString = service.GenerujJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcome to:" + userName;
        }

        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[]
                {
                    "Value1",
                    "vallue2",
                    "value3"
                };
        }
    }
}
