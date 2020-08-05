using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Uzytkownik
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public virtual Pracownik Pracownik { get; set; }
        public virtual Kierowca Kierowca { get; set; }
    }
}
