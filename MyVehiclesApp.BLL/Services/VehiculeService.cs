using MyVehiculesApp.Core;
using MyVehiculesApp.Core.Interfaces;
using MyVehiculeApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVehiculesApp.Core;

namespace MyVehiculesApp.BLL.Services
{
    public class VehiculeService : IVehiculeService
    {
        private readonly IVehiculeRepository _repo;

        public VehiculeService(IVehiculeRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Vehicule> Search(string immat, string marque)
        {
            // 🔥 Ici tu peux appliquer des règles métier avant d'appeler la DAL
            if (immat != null && immat.Length > 20)
                throw new DomainException("Immat too long.");

            return _repo.Search(immat, marque);
        }

        public Vehicule GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Vehicule vehicle)
        {
            Validate(vehicle);
            _repo.Add(vehicle);
        }

        public void Update(Vehicule vehicle)
        {
            Validate(vehicle);
            _repo.Update(vehicle);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        private void Validate(Vehicule v)
        {
            if (string.IsNullOrWhiteSpace(v.Immatriculation))
                throw new DomainException("L'immatriculation est obligatoire.");

            if (string.IsNullOrWhiteSpace(v.Marque))
                throw new DomainException("La marque est obligatoire.");

            // Ajoute ici toutes tes règles métier…
        }
    }
}
