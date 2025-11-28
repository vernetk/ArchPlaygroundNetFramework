using MyVehiculeApp.BLL.Services;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.DAL;
using MyVehiculeApp.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace MyVehiculeApp.IoC
{
    public static class UnityConfig
    {
        public static IUnityContainer Register()
        {
            var container = new UnityContainer();

            container.RegisterType<MyDbContext>(new TransientLifetimeManager());

            // DAL
            container.RegisterType<IVehiculeRepository, VehiculeRepository>();

            // BLL
            container.RegisterFactory<IVehiculeService>(c => c.Resolve<IVehiculeService>());
            container.RegisterType<IVehiculeService, VehiculeService>();

            return container;
        }
    }
}
