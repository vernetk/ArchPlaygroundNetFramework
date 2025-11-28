using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.UI.Views
{
    public interface IVehiculeDetailView
    {
        int Id { get; set; }
        string Immatriculation { get; set; }
        string Marque { get; set; }
        string Modele { get; set; }
        DateTime DateEntreeParc { get; set; }

        event EventHandler SaveRequested;

        //void ShowMessage(string msg);
        //void ShowError(string msg);
    }
}
