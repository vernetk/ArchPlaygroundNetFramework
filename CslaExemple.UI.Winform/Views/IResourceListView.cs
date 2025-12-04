using CslaExemple.BLLNetStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public interface IResourceListView
    {
        // Critères de recherche lus par le Presenter
        ResourceListViewModel ViewModel { get; }

        // Événement déclenché par la UI
        event EventHandler SearchRequested;
        event EventHandler<int> ResourceSelected;
        event EventHandler CreateRequested;
    }
}
