using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.Core
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Immatriculation { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public DateTime DateEntreeParc { get; set; }
    }
}
