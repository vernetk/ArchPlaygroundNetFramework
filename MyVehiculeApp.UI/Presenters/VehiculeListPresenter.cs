using MyVehiculeApp.BLL.Mappers;
using MyVehiculeApp.Core;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.Core.ViewModels;
using MyVehiculeApp.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.UI.Presenters
{
    public class VehiculeListPresenter : PresenterBase
    {
        #region Fields
        private readonly IVehiculeListView _view;
        // Func<IVehiculeService> est important pour instancier à chaque demande IVehiculeService (new ctx, sinon les modifs de la view Detail ne sont pas prise en compte).
        private readonly Func<IVehiculeService> _serviceFactory;
        private readonly INavigationService _nav;
        #endregion Fields

        #region Property
        private VehiculeListViewModel VM => _view.ViewModel;
        #endregion Property

        #region Ctrs
        public VehiculeListPresenter(
            IVehiculeListView view, 
            Func<IVehiculeService> serviceFactory, 
            INavigationService nav,
            IDialogService dialog) 
            : base(dialog)
        {
            _view = view;
            _serviceFactory = serviceFactory;
            _nav = nav;

            _view.SearchRequested += OnSearchRequested;
            _view.VehiculeSelected += OnVehiculeSelected;
            _view.CreateRequested += OnCreateRequested;
        }
        #endregion Ctrs

        #region Event handler
        private void OnVehiculeSelected(object sender, int id)
        {
            _nav.OpenVehiculeDetail(id, Refresh);
        }
        private void OnSearchRequested(object sender, EventArgs e)
        {
            try
            {
                var service = _serviceFactory();
                var list = service.Search(VM.SearchImmatriculation, VM.SearchMarque);
                VM.Items.Clear();
                foreach (var item in list.ToListItemViewModels())
                {
                    VM.Items.Add(item);
                }
            }
            catch (DomainException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Erreur inattendue : " + ex.Message);
            }
        }
        private void OnCreateRequested(object sender, EventArgs e)
        {
            _nav.CreateVehicule(Refresh);
        }
        #endregion Event handler

        #region Public methods
        public void Refresh()
        {
            OnSearchRequested(this, EventArgs.Empty);
        }
        #endregion Public methods
    }
}
