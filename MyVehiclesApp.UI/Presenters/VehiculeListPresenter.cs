using MyVehiculesApp.BLL.Mappers;
using MyVehiculesApp.Core;
using MyVehiculesApp.Core.Interfaces;
using MyVehiculesApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculesApp.UI.Presenters
{
    public class VehiculeListPresenter
    {
        private readonly IVehiculeListView _view;
        private readonly IVehiculeService _service;

        public VehiculeListPresenter(IVehiculeListView view, IVehiculeService service)
        {
            _view = view;
            _service = service;

            // Abonnement à l’event de la View
            _view.SearchRequested += OnSearchRequested;
        }

        private void OnSearchRequested(object sender, EventArgs e)
        {
            try
            {
                var list = _service.Search(_view.Immatriculation, _view.Marque);

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
