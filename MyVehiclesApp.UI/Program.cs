using MyVehiculesApp.Core.Interfaces;
using MyVehiculesApp.IoC;
using MyVehiculesApp.UI.Presenters;
using MyVehiculesApp.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace MyVehiculesApp.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = UnityConfig.Register();

            // Instancier la Form
            var view = new VehiculeListForm();

            // Résoudre la dépendance VehiculeService
            var service = container.Resolve<IVehiculeService>();

            // Créer le presenter en lui injectant la view + service
            var presenter = new VehiculeListPresenter(view, service);

            var factory = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            MessageBox.Show("Provider SQL OK");

            Application.Run((Form)view);
        }
    }
}
