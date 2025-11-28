using MyVehiculeApp.Core.Interfaces;
using MyVehiculeApp.IoC;
using MyVehiculeApp.UI.Presenters;
using MyVehiculeApp.UI.Services;
using MyVehiculeApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;

namespace MyVehiculeApp.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = UnityConfig.Register();
            UnityConfigUI.RegisterUI(container);

            // Récupération de la view pour la lancer.
            var view = container.Resolve<IVehiculeListView>();

            // Création du presenter (3 paramètres maintenant)
            var presenter = container.Resolve<VehiculeListPresenter>(new ParameterOverride("view", view));

            Application.Run((Form)view);
        }
    }
}
