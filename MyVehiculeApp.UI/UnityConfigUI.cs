using Unity;
using Unity.Lifetime;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.UI.Views;
using MyVehiculeApp.UI.Services;
using MyVehiculeApp.UI.Presenters;
using Unity.Injection;
using System;

namespace MyVehiculeApp.UI
{
    public static class UnityConfigUI
    {
        public static void RegisterUI(IUnityContainer container)
        {
            container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IVehiculeListView, VehiculeListForm>();
            container.RegisterType<IVehiculeDetailView, VehiculeDetailForm>();

            container.RegisterType<VehiculeListPresenter>();
            container.RegisterType<VehiculeDetailPresenter>();
        }
    }
}