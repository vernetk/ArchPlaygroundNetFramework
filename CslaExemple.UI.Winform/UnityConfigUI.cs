using Unity;
using Unity.Lifetime;
using Unity.Injection;
using System;

namespace CslaExemple.UI.Winform
{
    public static class UnityConfigUI
    {
        public static void RegisterUI(IUnityContainer container)
        {
            container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IResourceListView, ResourceListForm>();
            container.RegisterType<IResourceDetailView, ResourceDetailForm>();

            container.RegisterType<ResourceListPresenter>();
            container.RegisterType<ResourceDetailPresenter>();
        }
    }
}