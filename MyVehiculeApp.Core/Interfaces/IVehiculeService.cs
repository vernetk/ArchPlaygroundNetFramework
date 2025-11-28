using MyVehiculeApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.Core.Interfaces
{
    public interface IVehiculeService
    {
        IEnumerable<Vehicule> Search(string immat, string marque);
        Vehicule GetById(int id);
        void Create(Vehicule Vehicule);
        void Update(Vehicule Vehicule);
        void Delete(int id);
    }
}
