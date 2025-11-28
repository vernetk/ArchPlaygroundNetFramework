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
    public class VehiculeDetailPresenter : PresenterBase
    {
        private readonly IVehiculeDetailView _view;
        private readonly IVehiculeService _service;
        private readonly int _id;

        public VehiculeDetailPresenter(
            IVehiculeDetailView view, 
            IVehiculeService service,
            IDialogService dialog, 
            int id) 
            : base(dialog)
        {
            _view = view;
            _service = service;
            _id = id;

            _view.SaveRequested += OnSave;

            if (_id > 0)
                Load();
        }

        private void Load()
        {
            var v = _service.GetById(_id);
            if (v == null)
            {
                ShowError("Véhicule introuvable.");
                return;
            }

            _view.Id = v.Id;
            _view.Immatriculation = v.Immatriculation;
            _view.Marque = v.Marque;
            _view.Modele = v.Modele;
            _view.DateEntreeParc = v.DateEntreeParc;
        }

        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                var vehicule = new Vehicule
                {
                    Id = _id,
                    Immatriculation = _view.Immatriculation,
                    Marque = _view.Marque,
                    Modele = _view.Modele,
                    DateEntreeParc = _view.DateEntreeParc
                };

                if (_id > 0)
                    _service.Update(vehicule);
                else
                    _service.Create(vehicule);

                _view.ShowMessage("Enregistré !");
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
