using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.UI.Views;
using MyVehiculeApp.UI.Presenters;
using Unity;
using Unity.Resolution;
using System.Windows.Forms;

namespace MyVehiculeApp.UI.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IUnityContainer _container;

        public NavigationService(IUnityContainer container)
        {
            _container = container;
        }

        public void OpenVehiculeDetail(int id)
        {
            // 1) Créer la View (une instance fraîche)
            var view = _container.Resolve<IVehiculeDetailView>();

            // 2) Créer le Presenter en lui passant la View existante
            var presenter = _container.Resolve<VehiculeDetailPresenter>(
                new ParameterOverride("view", view),
                new ParameterOverride("id", id)
            );

            // 3) Ouvrir la modale
            ((Form)view).ShowDialog();
        }
    }
}
