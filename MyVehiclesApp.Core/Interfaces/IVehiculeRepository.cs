using MyVehiculesApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.Core.Interfaces
{
    public interface IVehiculeRepository
    {
        IEnumerable<Vehicule> Search(string immat, string marque);
        Vehicule GetById(int id);
        void Add(Vehicule vehicle);
        void Update(Vehicule vehicle);
        void Delete(int id);
    }
}
