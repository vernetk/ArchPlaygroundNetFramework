using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchPlaygroundNetFramework.Dal
{
    public interface IVehiculeDal
    {
        VehiculeDto GetById(int id);
        IEnumerable<VehiculeDto> Search(VehiculeSearchCriteria criteria, ref int count);
    }
}
