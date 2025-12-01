using MyVehiculeApp.Core;
using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.Core.ViewModels;
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

        private VehiculeDetailViewModel VM => _view.ViewModel;

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

            VM.PropertyChanged += (s, e) => ValidateAndShowErrors();

            _view.SetMode(_id == 0 ? FormMode.Create : FormMode.Edit);

            if (_id > 0)
                LoadData();

        }

        private void LoadData()
        {
            var v = _service.GetById(_id);
            if (v == null)
            {
                ShowError("Véhicule introuvable.");
                return;
            }

            VM.Id = v.Id;
            VM.Immatriculation = v.Immatriculation;
            VM.Marque = v.Marque;
            VM.Modele = v.Modele;
            VM.DateEntreeParc = v.DateEntreeParc;

        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateAndShowErrors())
                return;

            var vehicule = new Vehicule
            {
                Id = VM.Id,
                Immatriculation = VM.Immatriculation,
                Marque = VM.Marque,
                Modele = VM.Modele,
                DateEntreeParc = VM.DateEntreeParc
            };

            try
            {
                if (_id > 0)
                    _service.Update(vehicule);
                else
                    _service.Create(vehicule);

                ShowInfo("Enregistré !");
                _view.Close();
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

        private bool ValidateAndShowErrors()
        {
            _view.ClearErrors();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(VM.Immatriculation))
            {
                _view.SetError(nameof(VM.Immatriculation), "L'immatriculation est obligatoire.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(VM.Marque))
            {
                _view.SetError(nameof(VM.Marque), "La marque est obligatoire.");
                isValid = false;
            }

            if (VM.DateEntreeParc > DateTime.Now)
            {
                _view.SetError(nameof(VM.DateEntreeParc), "La date ne peut pas être dans le futur.");
                isValid = false;
            }

            _view.SetSaveButtonEnabled(isValid);
            return isValid;
        }
    }
}
