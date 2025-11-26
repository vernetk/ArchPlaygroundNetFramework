using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class VehiculeRepository
    {
        private static readonly List<Vehicule> _data = new List<Vehicule>
        {
            new Vehicule { Id = 1, Marque = "Renault", Modele = "Clio", Annee = 2015 },
            new Vehicule { Id = 2, Marque = "Peugeot", Modele = "208", Annee = 2018 },
            new Vehicule { Id = 3, Marque = "Citroen", Modele = "C3", Annee = 2017 },
            new Vehicule { Id = 4, Marque = "Tesla", Modele = "Model 3", Annee = 2020 },
            new Vehicule { Id = 5, Marque = "BMW", Modele = "Serie 1", Annee = 2019 }
        };

        public IEnumerable<Vehicule> GetAll() => _data;

        public Vehicule Get(int id) => _data.FirstOrDefault(v => v.Id == id);
    }
}