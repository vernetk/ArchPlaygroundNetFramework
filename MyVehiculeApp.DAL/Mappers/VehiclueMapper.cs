using MyVehiculeApp.Core;
using MyVehiculeApp.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.DAL.Mappers
{
    public static class VehiculeMapper
    {
        public static Vehicule ToModel(this VehiculeEntity entity)
        {
            if (entity == null) return null;

            return new Vehicule
            {
                Id = entity.Id,
                Immatriculation = entity.Immatriculation,
                Marque = entity.Marque,
                Modele = entity.Modele,
                DateEntreeParc = entity.DateEntreeParc
            };
        }

        public static VehiculeEntity ToEntity(this Vehicule model)
        {
            if (model == null) return null;

            return new VehiculeEntity
            {
                Id = model.Id,
                Immatriculation = model.Immatriculation,
                Marque = model.Marque,
                Modele = model.Modele,
                DateEntreeParc = model.DateEntreeParc
            };
        }
    }
}
