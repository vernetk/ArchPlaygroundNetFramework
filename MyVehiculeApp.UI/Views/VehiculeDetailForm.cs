using MyVehiculeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVehiculeApp.UI.Views
{
    public partial class VehiculeDetailForm : Form, IVehiculeDetailView
    {
        public VehiculeDetailViewModel ViewModel { get; private set; }

        public VehiculeDetailForm()
        {
            InitializeComponent();

            ViewModel = new VehiculeDetailViewModel();

            txtImmatriculation.DataBindings.Add("Text", ViewModel, nameof(VehiculeDetailViewModel.Immatriculation), true, DataSourceUpdateMode.OnPropertyChanged);
            txtMarque.DataBindings.Add("Text", ViewModel, nameof(VehiculeDetailViewModel.Marque), true, DataSourceUpdateMode.OnPropertyChanged);
            txtModele.DataBindings.Add("Text", ViewModel, nameof(VehiculeDetailViewModel.Modele), true, DataSourceUpdateMode.OnPropertyChanged);
            dtpDateEntree.DataBindings.Add("Value", ViewModel, nameof(VehiculeDetailViewModel.DateEntreeParc), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public event EventHandler SaveRequested;

        public void Close()
        {
            base.Close();    // on appelle la version Form.Close()
        }

        public void SetMode(FormMode mode)
        {
            if (mode == FormMode.Create)
            {
                Text = "Créer un véhicule";
                btnSave.Text = "Créer";
            }
            else
            {
                Text = "Modifier un véhicule";
                btnSave.Text = "Enregistrer";
            }
        }
        public void SetError(string propertyName, string message)
        {
            switch (propertyName)
            {
                case nameof(ViewModel.Immatriculation):
                    errorProvider.SetError(txtImmatriculation, message);
                    break;

                case nameof(ViewModel.Marque):
                    errorProvider.SetError(txtMarque, message);
                    break;
                case nameof(ViewModel.Modele):
                    errorProvider.SetError(txtModele, message);
                    break;

                case nameof(ViewModel.DateEntreeParc):
                    errorProvider.SetError(dtpDateEntree, message);
                    break;
            }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetSaveButtonEnabled(bool enabled)
        {
            btnSave.Enabled = enabled;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }
        //public void ShowMessage(string msg) => MessageBox.Show(msg);
        //public void ShowError(string msg) => MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
