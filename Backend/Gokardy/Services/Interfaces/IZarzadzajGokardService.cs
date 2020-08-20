using Gokardy.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Interfaces
{
    public interface IZarzadzajGokardService
    {
        public void PersonalizujGokard(PersonalizujGokardaRequest request, int Id);
    }
}
