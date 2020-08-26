using Gokardy.Models;
using Gokardy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Services.Classes
{
    public class ZarzadzajPracownikService : IZarzadzajPracownikService
    {
        private GokardyContext context;
        public ZarzadzajPracownikService(GokardyContext context)
        {
            this.context = context;
        }
        public void UsunPracownika(int Id)
        {
            var pracownik = context.Pracownik.FirstOrDefault(e => e.Id == Id);
            context.Pracownik.Remove(pracownik);         
            context.SaveChanges();
        }
    }
}
