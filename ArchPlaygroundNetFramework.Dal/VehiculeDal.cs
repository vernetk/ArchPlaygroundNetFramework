using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchPlaygroundNetFramework.Dal
{
    public class VehiculeDal : IVehiculeDal
    {
        private readonly List<VehiculeDto> _vehicules;

        public VehiculeDal()
        {
            _vehicules = new List<VehiculeDto>
        {
            new VehiculeDto { Id = 1,  Immatriculation = "AA-123-AA", Marque = "Renault",   Modele = "Clio",         Annee = 2018, Prix = 8500,  DateArrivee = DateTime.Parse("2024-01-12") },
            new VehiculeDto { Id = 2,  Immatriculation = "BB-456-BB", Marque = "Peugeot",   Modele = "208",          Annee = 2019, Prix = 9200,  DateArrivee = DateTime.Parse("2024-02-10") },
            new VehiculeDto { Id = 3,  Immatriculation = "CC-789-CC", Marque = "Citroen",   Modele = "C3",           Annee = 2020, Prix = 9800,  DateArrivee = DateTime.Parse("2024-03-22") },
            new VehiculeDto { Id = 4,  Immatriculation = "DD-111-DD", Marque = "Ford",      Modele = "Focus",        Annee = 2017, Prix = 7500,  DateArrivee = DateTime.Parse("2024-01-20") },
            new VehiculeDto { Id = 5,  Immatriculation = "EE-222-EE", Marque = "Toyota",    Modele = "Yaris",        Annee = 2021, Prix = 12000, DateArrivee = DateTime.Parse("2024-02-01") },
            new VehiculeDto { Id = 6,  Immatriculation = "FF-333-FF", Marque = "Volkswagen",Modele = "Golf",         Annee = 2016, Prix = 6800,  DateArrivee = DateTime.Parse("2024-03-01") },
            new VehiculeDto { Id = 7,  Immatriculation = "GG-444-GG", Marque = "Audi",      Modele = "A3",           Annee = 2018, Prix = 14500, DateArrivee = DateTime.Parse("2024-03-12") },
            new VehiculeDto { Id = 8,  Immatriculation = "HH-555-HH", Marque = "BMW",       Modele = "Serie 1",      Annee = 2017, Prix = 13900, DateArrivee = DateTime.Parse("2024-04-10") },
            new VehiculeDto { Id = 9,  Immatriculation = "II-666-II", Marque = "Mercedes",  Modele = "Classe A",     Annee = 2019, Prix = 18500, DateArrivee = DateTime.Parse("2024-03-28") },
            new VehiculeDto { Id = 10, Immatriculation = "JJ-777-JJ", Marque = "Opel",      Modele = "Corsa",        Annee = 2015, Prix = 5900,  DateArrivee = DateTime.Parse("2024-02-22") },
            new VehiculeDto { Id = 11, Immatriculation = "KK-888-KK", Marque = "Nissan",    Modele = "Micra",        Annee = 2020, Prix = 9000,  DateArrivee = DateTime.Parse("2024-01-30") },
            new VehiculeDto { Id = 12, Immatriculation = "LL-999-LL", Marque = "Hyundai",   Modele = "i20",          Annee = 2021, Prix = 11000, DateArrivee = DateTime.Parse("2024-05-03") },
            new VehiculeDto { Id = 13, Immatriculation = "MM-000-MM", Marque = "Kia",       Modele = "Rio",          Annee = 2018, Prix = 8900,  DateArrivee = DateTime.Parse("2024-04-22") },
            new VehiculeDto { Id = 14, Immatriculation = "NN-111-NN", Marque = "Seat",      Modele = "Ibiza",        Annee = 2017, Prix = 7500,  DateArrivee = DateTime.Parse("2024-03-19") },
            new VehiculeDto { Id = 15, Immatriculation = "OO-222-OO", Marque = "Skoda",     Modele = "Fabia",        Annee = 2016, Prix = 6100,  DateArrivee = DateTime.Parse("2024-02-16") },
            new VehiculeDto { Id = 16, Immatriculation = "PP-333-PP", Marque = "Renault",   Modele = "Megane",       Annee = 2019, Prix = 10500, DateArrivee = DateTime.Parse("2024-03-08") },
            new VehiculeDto { Id = 17, Immatriculation = "QQ-444-QQ", Marque = "Peugeot",   Modele = "308",          Annee = 2020, Prix = 11900, DateArrivee = DateTime.Parse("2024-04-05") },
            new VehiculeDto { Id = 18, Immatriculation = "RR-555-RR", Marque = "Toyota",    Modele = "Corolla",      Annee = 2021, Prix = 16000, DateArrivee = DateTime.Parse("2024-05-10") },
            new VehiculeDto { Id = 19, Immatriculation = "SS-666-SS", Marque = "Mazda",     Modele = "Mazda 3",      Annee = 2017, Prix = 9700,  DateArrivee = DateTime.Parse("2024-04-15") },
            new VehiculeDto { Id = 20, Immatriculation = "TT-777-TT", Marque = "Honda",     Modele = "Civic",        Annee = 2018, Prix = 11200, DateArrivee = DateTime.Parse("2024-05-01") }
        };
        }

        public VehiculeDto GetById(int id)
        {
            return _vehicules.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<VehiculeDto> Search(VehiculeSearchCriteria c, ref int count)
        {
            var query = _vehicules.AsQueryable()
                .Where(v => string.IsNullOrWhiteSpace(c.Marque) || v.Marque.Contains(c.Marque))
            .Where(v => string.IsNullOrWhiteSpace(c.Marque) || v.Marque.Contains(c.Modele));

            if (c.AnneeMin.HasValue)
                query = query.Where(v => v.Annee >= c.AnneeMin.Value);

            if (c.AnneeMax.HasValue)
                query = query.Where(v => v.Annee <= c.AnneeMax.Value);

            if (c.PrixMin.HasValue)
                query = query.Where(v => v.Prix >= c.PrixMin.Value);

            if (c.PrixMax.HasValue)
                query = query.Where(v => v.Prix <= c.PrixMax.Value);

            count = query.Count();

            return query
                .OrderBy(v => v.Id)
                .Skip((c.Page - 1) * c.PageSize)
                .Take(c.PageSize)
                .Select(v => new VehiculeDto
                {
                    Id = v.Id,
                    Immatriculation = v.Immatriculation,
                    Marque = v.Marque,
                    Modele = v.Modele,
                    Annee = v.Annee,
                    Prix = v.Prix,
                    DateArrivee = v.DateArrivee,
                })
                .ToList();
        }
    }
}
