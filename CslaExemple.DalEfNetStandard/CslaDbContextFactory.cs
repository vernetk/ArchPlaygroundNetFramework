using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CslaExemple.DalEfNetStandard
{
    public class CslaDbContextFactory : IDesignTimeDbContextFactory<CslaDbContext>
    {
        public CslaDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();

            var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            var connectionString = config.GetConnectionString("CslaExempleDBConnexion");

            var optionsBuilder = new DbContextOptionsBuilder<CslaDbContext>();
            optionsBuilder.UseSqlServer(
                config.GetConnectionString("CslaExempleDBConnexion")
            );

            return new CslaDbContext(optionsBuilder.Options);
        }
    }
}
