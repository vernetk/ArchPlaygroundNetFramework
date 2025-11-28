using MyVehiculeApp.BLL.Mappers;
using MyVehiculeApp.Core;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.UI.Presenters
{
    public class VehiculeListPresenter
    {
        private readonly IVehiculeListView _view;
        private readonly Func<IVehiculeService> _serviceFactory;
        private readonly INavigationService _nav;

        public VehiculeListPresenter(IVehiculeListView view, Func<IVehiculeService> serviceFactory, INavigationService nav)
        {
            _view = view;
            _serviceFactory = serviceFactory;
            _nav = nav;

            _view.SearchRequested += OnSearchRequested;
            _view.VehiculeSelected += OnVehiculeSelected;
        }

        private void OnVehiculeSelected(object sender, int id)
        {
            _nav.OpenVehiculeDetail(id);

            // Recharger la liste après fermeture
            OnSearchRequested(this, EventArgs.Empty);
        }

        private void OnSearchRequested(object sender, EventArgs e)
        {
            try
            {
                var service = _serviceFactory();
                var list = service.Search(_view.Immatriculation, _view.Marque);

                // map domain → viewmodel
                var vm = list.ToListItemViewModels();

                _view.DisplayVehicules(vm);
            }
            catch (DomainException ex)
            {
                _view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowError("Erreur inattendue : " + ex.Message);
            }
        }
    }
}
