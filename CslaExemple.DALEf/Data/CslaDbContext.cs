using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DALEf
{
    public class CslaDbContext : DbContext
    {
        public CslaDbContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("IvecoDBConnexion").ToString();
        }

        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .ToTable("Resources")
                .HasKey(v => v.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
