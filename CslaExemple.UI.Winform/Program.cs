using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Resolution;

namespace CslaExemple.UI.Winform
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var container = new UnityContainer();
            UnityConfigUI.RegisterUI(container);

            // Récupération de la view pour la lancer.
            var view = container.Resolve<IResourceListView>();

            // Création du presenter (3 paramètres maintenant)
            var presenter = container.Resolve<ResourceListPresenter>(new ParameterOverride("view", view));

            Application.Run((Form)view);

        }
    }
}
