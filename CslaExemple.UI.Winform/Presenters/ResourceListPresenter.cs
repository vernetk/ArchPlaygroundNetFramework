using CslaExemple.BLLNetStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public class ResourceListPresenter : PresenterBase
    {
        #region Fields
        private readonly IResourceListView _view;
        // Func<IResourceService> est important pour instancier à chaque demande IResourceService (new ctx, sinon les modifs de la view Detail ne sont pas prise en compte).
        private readonly INavigationService _nav;
        #endregion Fields

        #region Property
        private ResourceListViewModel VM => _view.ViewModel;
        #endregion Property

        #region Ctrs
        public ResourceListPresenter(
            IResourceListView view, 
            INavigationService nav,
            IDialogService dialog) 
            : base(dialog)
        {
            _view = view;
            _nav = nav;

            _view.SearchRequested += OnSearchRequested;
            _view.ResourceSelected += OnResourceSelected;
            _view.CreateRequested += OnCreateRequested;
        }
        #endregion Ctrs

        #region Event handler
        private void OnResourceSelected(object sender, int id)
        {
            _nav.OpenResourceDetail(id, Refresh);
        }
        private async void OnSearchRequested(object sender, EventArgs e)
        {
            try
            {
                var list = await ResourceList.GetResourceListAsync();
                VM.Items.Clear();
                foreach (var item in list)
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
            _nav.CreateResource(Refresh);
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
