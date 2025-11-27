using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculesApp.DAL.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyVehiculeDb") // nom dans App.config
        {
        }

        public DbSet<VehiculeEntity> Vehicules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehiculeEntity>()
                .ToTable("Vehicules")
                .HasKey(v => v.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
