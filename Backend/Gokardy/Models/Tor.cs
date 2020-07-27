﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public partial class Tor
    {
        public Tor()
        {
            Przejazd = new HashSet<Przejazd>();
            Gokard = new HashSet<Gokard>();
            Pracownik = new HashSet<Pracownik>();
        }

        public int IdTor { get; set; }
        public string Nazwa { get; set; }
        public double Długosc { get; set; }
        public double StawkaGodzinowa { get; set; }
        public int IdAdres { get; set; }

        public virtual Adres IdAdresNavigation { get; set; }
        public virtual ICollection<Przejazd> Przejazd { get; set; }
        public virtual ICollection<Gokard> Gokard { get; set; }
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}
