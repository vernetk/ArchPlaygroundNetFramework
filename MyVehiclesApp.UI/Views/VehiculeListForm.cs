using MyVehiculesApp.Core.ViewModels;
using MyVehiculesApp.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVehiculesApp.UI
{
    public partial class VehiculeListForm : Form, IVehiculeListView
    {
        public VehiculeListForm()
        {
            InitializeComponent();
        }

        // Champs exposés au presenter
        public string Immatriculation => txtImmatriculation.Text;
        public string Marque => txtMarque.Text;

        // Event exposé au Presenter
        public event EventHandler SearchRequested;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, EventArgs.Empty);
        }

        // Méthode appelée par le Presenter
        public void DisplayVehicules(IEnumerable<VehiculeListItemViewModel> vehicules)
        {
            gridVehicules.DataSource = vehicules;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
