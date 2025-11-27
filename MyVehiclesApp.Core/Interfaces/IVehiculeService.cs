using MyVehiculesApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculesApp.Core.Interfaces
{
    public interface IVehiculeService
    {
        IEnumerable<Vehicule> Search(string immat, string marque);
        Vehicule GetById(int id);
        void Create(Vehicule vehicle);
        void Update(Vehicule vehicle);
        void Delete(int id);
    }
}
