using MyVehiculeApp.Core;
using MyVehiculeApp.DAL.EF;
using MyVehiculeApp.DAL.Mappers;
using MyVehiculeApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.DAL
{
    public class VehiculeRepository : IVehiculeRepository
    {
        private readonly MyDbContext _ctx;

        public VehiculeRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Vehicule> Search(string immat, string marque)
        {
            var query = _ctx.Vehicules.AsQueryable();

            if (!string.IsNullOrWhiteSpace(immat))
                query = query.Where(v => v.Immatriculation.Contains(immat));

            if (!string.IsNullOrWhiteSpace(marque))
                query = query.Where(v => v.Marque.Contains(marque));

            return query
                .ToList()
                .Select(x => x.ToModel())
                .ToList();
        }

        public Vehicule GetById(int id)
        {
            var entity = _ctx.Vehicules.Find(id);
            return entity?.ToModel();
        }

        public void Add(Vehicule Vehicule)
        {
            var entity = Vehicule.ToEntity();
            _ctx.Vehicules.Add(entity);
            _ctx.SaveChanges();
            Vehicule.Id = entity.Id;
        }

        public void Update(Vehicule Vehicule)
        {
            var entity = _ctx.Vehicules.Find(Vehicule.Id);
            if (entity == null) return;

            _ctx.Entry(entity).CurrentValues.SetValues(Vehicule.ToEntity());
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _ctx.Vehicules.Find(id);
            if (entity == null) return;

            _ctx.Vehicules.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
