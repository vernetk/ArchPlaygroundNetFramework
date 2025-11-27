using MyVehiculesApp.Core;
using MyVehiculesApp.DAL.EF;
using MyVehiculesApp.DAL.Mappers;
using MyVehiculeApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculesApp.DAL
{
    public class VehiculeRepository : IVehiculeRepository
    {
        public IEnumerable<Vehicule> Search(string immat, string marque)
        {
            using (var ctx = new MyDbContext())
            {
                var query = ctx.Vehicules.AsQueryable();

                if (!string.IsNullOrWhiteSpace(immat))
                    query = query.Where(v => v.Immatriculation.Contains(immat));

                if (!string.IsNullOrWhiteSpace(marque))
                    query = query.Where(v => v.Marque.Contains(marque));

                return query
                    .ToList()
                    .Select(x => x.ToModel())
                    .ToList();
            }
        }

        public Vehicule GetById(int id)
        {
            using (var ctx = new MyDbContext())
            {
                var entity = ctx.Vehicules.Find(id);
                return entity?.ToModel();
            }
        }

        public void Add(Vehicule vehicle)
        {
            using (var ctx = new MyDbContext())
            {
                var entity = vehicle.ToEntity();
                ctx.Vehicules.Add(entity);
                ctx.SaveChanges();
                vehicle.Id = entity.Id;
            }
        }

        public void Update(Vehicule vehicle)
        {
            using (var ctx = new MyDbContext())
            {
                var entity = ctx.Vehicules.Find(vehicle.Id);
                if (entity == null) return;

                ctx.Entry(entity).CurrentValues.SetValues(vehicle.ToEntity());
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new MyDbContext())
            {
                var entity = ctx.Vehicules.Find(id);
                if (entity == null) return;

                ctx.Vehicules.Remove(entity);
                ctx.SaveChanges();
            }
        }
    }
}
