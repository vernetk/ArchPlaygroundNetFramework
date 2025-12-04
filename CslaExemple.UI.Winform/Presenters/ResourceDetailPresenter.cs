using Csla.Rules;
using CslaExemple.BLLNetStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public class ResourceDetailPresenter : PresenterBase
    {
        private readonly IResourceDetailView _view;
        private readonly int _id;

        private ResourceDetailViewModel VM => _view.ViewModel;

        public ResourceDetailPresenter(
            IResourceDetailView view, 
            IDialogService dialog, 
            int id) 
            : base(dialog)
        {
            _view = view;
            _id = id;

            _view.SaveRequested += OnSave;

            VM.PropertyChanged += (s, e) => ValidateAndShowErrors();
            _view.SetMode(_id == 0 ? FormMode.Create : FormMode.Edit);

            if (_id > 0) LoadData();
            else CreateData();
            
            
        }

        private async void LoadData()
        {
            var resourceEdit = await ResourceEdit.GetResourceEditAsync(_id);
            if (resourceEdit == null)
            {
                ShowError("Resource introuvable.");
                return;
            }

            VM.ModelEdit = resourceEdit;
            VM.ModelEdit.PropertyChanged += (s, e) => ValidateAndShowErrors();
        }

        private async void CreateData()
        {
            var resourceEdit = await ResourceEdit.NewResourceEditAsync();
            VM.ModelEdit = resourceEdit;
            VM.ModelEdit.PropertyChanged += (s, e) => ValidateAndShowErrors();
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateAndShowErrors())
                return;
            try
            {
                if (VM.ModelEdit.IsDirty && VM.ModelEdit.IsSavable)
                {
                    VM.ModelEdit.ApplyEdit();
                    VM.ModelEdit = VM.ModelEdit.Save();
                }
                else
                {
                    var message = "Project is invalid and cannot be saved." + Environment.NewLine + Environment.NewLine;
                    foreach (var rule in VM.ModelEdit.BrokenRulesCollection)
                    {
                        if (rule.Severity == RuleSeverity.Error)
                            message += "- " + rule.Description + Environment.NewLine;
                    }
                    ShowError(message);
                    return;
                }
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

            if (string.IsNullOrWhiteSpace(VM.ModelEdit.FirstName))
            {
                _view.SetError(nameof(VM.ModelEdit.FirstName), "L'FirstName est obligatoire.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(VM.ModelEdit.LastName))
            {
                _view.SetError(nameof(VM.ModelEdit.LastName), "La LastName est obligatoire.");
                isValid = false;
            }
            _view.SetSaveButtonEnabled(isValid);
            return isValid;
        }
    }
}
