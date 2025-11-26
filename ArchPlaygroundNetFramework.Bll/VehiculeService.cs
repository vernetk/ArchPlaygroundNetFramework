using ArchPlaygroundNetFramework.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchPlaygroundNetFramework.Bll
{
    public class VehiculeService : IVehiculeService
    {
        private readonly IVehiculeDal _dal;

        public VehiculeService(IVehiculeDal dal)
        {
            _dal = dal;
        }

        public async Task<Vehicule> GetAsync(int id)
        {
            var dto = _dal.GetById(id);
            if (dto == null) return null;

            return new Vehicule
            {
                Id = dto.Id,
                Immatriculation = dto.Immatriculation,
                Marque = dto.Marque,
                Modele = dto.Modele,
                Annee = dto.Annee,
                Prix = dto.Prix,
                DateArrivee = dto.DateArrivee
            };
        }

        public async Task<PagingResult<Vehicule>> SearchAsync(VehiculeSearchCriteria criteria)
        {
            var total = 0;
            var items = _dal.Search(criteria, ref total);

            var list = items.Select(dto => new Vehicule
            {
                Id = dto.Id,
                Immatriculation = dto.Immatriculation,
                Marque = dto.Marque,
                Modele = dto.Modele,
                Annee = dto.Annee,
                Prix = dto.Prix,
                DateArrivee = dto.DateArrivee
            }).ToList();

            return new PagingResult<Vehicule>
            {
                Items = list,
                Page = criteria.Page,
                PageSize = criteria.PageSize,
                TotalCount = total // optionnel : récupérer via COUNT()
            };
        }
    }
}
