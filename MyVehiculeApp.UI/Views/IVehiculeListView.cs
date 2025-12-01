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
        VehiculeListViewModel ViewModel { get; }

        // Événement déclenché par la UI
        event EventHandler SearchRequested;
        event EventHandler<int> VehiculeSelected;
        event EventHandler CreateRequested;
    }
}
