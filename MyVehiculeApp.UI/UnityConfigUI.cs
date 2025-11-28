using Unity;
using Unity.Lifetime;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.UI.Views;
using MyVehiculeApp.UI.Services;
using MyVehiculeApp.UI.Presenters;

namespace MyVehiculeApp.UI
{
    public static class UnityConfigUI
    {
        public static void RegisterUI(IUnityContainer container)
        {
            //
            // --- 1. Services spécifiques à la couche UI ---
            container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());

            //
            // --- 2. Views ---
            //
            // View principale → Singleton (doit être unique dans l'app)
            container.RegisterType<IVehiculeListView, VehiculeListForm>();

            // Views secondaires → Transient (une instance par ouverture)
            container.RegisterType<IVehiculeDetailView, VehiculeDetailForm>();

            //
            // --- 3. Presenters ---
            //
            // Toujours en Transient (un Presenter par ouverture d'écran)
            container.RegisterType<VehiculeListPresenter>();
            container.RegisterType<VehiculeDetailPresenter>();
        }
    }
}