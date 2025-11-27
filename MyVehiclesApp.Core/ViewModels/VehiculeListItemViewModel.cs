using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculesApp.Core.ViewModels
{
    public class VehiculeListItemViewModel
    {
        public int Id { get; set; }
        public string Immatriculation { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string DateEntreeParc { get; set; } // format string pour la UI
    }
}
