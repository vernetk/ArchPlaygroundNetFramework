using MyVehiculeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.UI.Views
{
    public interface IVehiculeListView
    {
        // Critères de recherche lus par le Presenter
        string Immatriculation { get; }
        string Marque { get; }

        // Événement déclenché par la UI
        event EventHandler SearchRequested;
        event EventHandler<int> VehiculeSelected;

        // Méthode pour afficher la liste
        void DisplayVehicules(IEnumerable<VehiculeListItemViewModel> vehicules);

        // Gestion erreurs
        //void ShowError(string message);
    }
}
