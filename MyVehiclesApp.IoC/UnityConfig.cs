using MyVehiculesApp.BLL.Services;
using MyVehiculesApp.Core.Interfaces;
using MyVehiculesApp.DAL;
using MyVehiculeApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MyVehiculesApp.IoC
{
    public static class UnityConfig
    {
        public static IUnityContainer Register()
        {
            var container = new UnityContainer();

            // DAL
            container.RegisterType<IVehiculeRepository, VehiculeRepository>();

            // BLL
            container.RegisterType<IVehiculeService, VehiculeService>();

            return container;
        }
    }
}
