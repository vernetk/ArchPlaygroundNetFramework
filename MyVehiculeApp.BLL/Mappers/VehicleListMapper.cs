using MyVehiculeApp.Core;
using MyVehiculeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.BLL.Mappers
{
    public static class VehiculeListMapper
    {
        public static VehiculeListItemViewModel ToListItemViewModel(this Vehicule v)
        {
            return new VehiculeListItemViewModel
            {
                Id = v.Id,
                Immatriculation = v.Immatriculation,
                Marque = v.Marque,
                Modele = v.Modele,
                DateEntreeParc = v.DateEntreeParc.ToString("dd/MM/yyyy")
            };
        }

        public static IEnumerable<VehiculeListItemViewModel> ToListItemViewModels(this IEnumerable<Vehicule> list)
        {
            return list.Select(v => v.ToListItemViewModel()).ToList();
        }
    }
}
