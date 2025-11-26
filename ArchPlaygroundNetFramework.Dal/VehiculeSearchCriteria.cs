using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchPlaygroundNetFramework.Dal
{
    public class VehiculeSearchCriteria
    {
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int? AnneeMin { get; set; }
        public int? AnneeMax { get; set; }
        public decimal? PrixMin { get; set; }
        public decimal? PrixMax { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public VehiculeSearchCriteria()
        {

        }
    }
}
