using CslaExemple.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DALEf
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Add the services for ProjectTracker.Dal that
        /// use Entity Framework
        /// </summary>
        /// <param name="services"></param>
        public static void AddDalEfCore(this IServiceCollection services)
        {
            services.AddScoped<CslaDbContext>();
            services.AddTransient<IResourceDal, ResourceDal>();
        }
    }
}
