using ArchPlaygroundNetFramework.Bll;
using ArchPlaygroundNetFramework.Dal;
using ArchPlaygroundNetFramework.WebApiRest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace ArchPlaygroundNetFramework.WebApiRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 2. UNITY CONTAINER
            var container = new UnityContainer();

            // DAL
            container.RegisterType<IVehiculeDal, VehiculeDal>(new HierarchicalLifetimeManager());

            // BLL
            container.RegisterType<IVehiculeService, VehiculeService>(new HierarchicalLifetimeManager());

            // LinkBuilder (sans dépendances)
            container.RegisterType<LinkBuilder>(new TransientLifetimeManager());

            // Affectation du resolver
            config.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}
