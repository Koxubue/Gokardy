using Gokardy.DTOs.Responses;
using Gokardy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface IZarzadajKierowcaService
    {
        public List<KierowcaBezSponsoraResponse> KierowcaBezSponsora();
    }
}
