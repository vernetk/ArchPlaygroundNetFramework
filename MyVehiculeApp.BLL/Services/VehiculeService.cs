using MyVehiculeApp.Core;
using MyVehiculeApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVehiculeApp.Core;

namespace MyVehiculeApp.BLL.Services
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
            return _repo.Search(immat, marque);
        }

        public Vehicule GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Vehicule Vehicule)
        {
            Validate(Vehicule);
            _repo.Add(Vehicule);
        }

        public void Update(Vehicule Vehicule)
        {
            Validate(Vehicule);
            _repo.Update(Vehicule);
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
