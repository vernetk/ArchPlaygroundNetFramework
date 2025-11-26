using ArchPlaygroundNetFramework.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchPlaygroundNetFramework.Bll
{
    public interface IVehiculeService
    {
        Task<Vehicule> GetAsync(int id);
        Task<PagingResult<Vehicule>> SearchAsync(VehiculeSearchCriteria criteria);
    }
}
