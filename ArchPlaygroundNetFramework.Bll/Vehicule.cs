using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchPlaygroundNetFramework.Bll
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Immatriculation { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public decimal Prix { get; set; }
        public DateTime DateArrivee { get; set; }
    }
}
