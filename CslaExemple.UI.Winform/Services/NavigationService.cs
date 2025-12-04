using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;
using System.Windows.Forms;

namespace CslaExemple.UI.Winform
{
    public class NavigationService : INavigationService
    {
        private readonly IUnityContainer _container;

        public NavigationService(IUnityContainer container)
        {
            _container = container;
        }

        public void OpenResourceDetail(int id, Action afterClose = null)
        {
            // 1) Créer la View (une instance fraîche)
            var view = _container.Resolve<IResourceDetailView>();

            // 2) Créer le Presenter en lui passant la View existante
            var presenter = _container.Resolve<ResourceDetailPresenter>(
                new ParameterOverride("view", view),
                new ParameterOverride("id", id)
            );

            var form = (Form)view;

            if (afterClose != null)
            {
                form.FormClosed += (s, e) => afterClose();
            }

            ((Form)view).ShowDialog();
        }

        public void CreateResource(Action afterClose = null)
        {
            // 1) Créer la View (une instance fraîche)
            var view = _container.Resolve<IResourceDetailView>();

            // 2) Créer le Presenter en lui passant la View existante
            var presenter = _container.Resolve<ResourceDetailPresenter>(
                new ParameterOverride("view", view),
                new ParameterOverride("id", 0)
            );

            var form = (Form)view;

            if (afterClose != null)
            {
                form.FormClosed += (s, e) => afterClose();
            }

            ((Form)view).ShowDialog();
        }
    }
}
