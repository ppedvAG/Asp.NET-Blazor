using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalloWeb.Models
{
    public class Klopapier
    {
        public int Id { get; set; }
        public int AnzahlBlatt { get; set; }
        public string Hersteller { get; set; }
        public string Produkt { get; set; }
        public int Langen { get; set; }
        public string Duft { get; set; }

    }
}
