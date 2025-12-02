using CslaExemple.DalNetStandard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DalEfNetStandard
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Add the services for ProjectTracker.Dal that
        /// use Entity Framework
        /// </summary>
        /// <param name="services"></param>
        public static void AddDalEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CslaDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("CslaExempleDBConnexion")), contextLifetime: ServiceLifetime.Transient);

            services.AddTransient<IResourceDal, ResourceDal>();
        }
    }
}
