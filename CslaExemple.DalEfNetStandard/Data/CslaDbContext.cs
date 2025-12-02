using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DalEfNetStandard
{
    public class CslaDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }

        public CslaDbContext(DbContextOptions<CslaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .ToTable("Resources")
                .HasKey(v => v.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
