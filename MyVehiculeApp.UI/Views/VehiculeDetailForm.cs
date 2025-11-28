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
        public VehiculeDetailForm()
        {
            InitializeComponent();
        }

        public int Id { get; set; }
        public string Immatriculation { get => txtImmatriculation.Text; set => txtImmatriculation.Text = value; }
        public string Marque { get => txtMarque.Text; set => txtMarque.Text = value; }
        public string Modele { get => txtModele.Text; set => txtModele.Text = value; }
        public DateTime DateEntreeParc { get => dtpDateEntree.Value; set => dtpDateEntree.Value = value; }

        public event EventHandler SaveRequested;

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRequested?.Invoke(this, EventArgs.Empty);
        }

        public void ShowMessage(string msg) => MessageBox.Show(msg);
        public void ShowError(string msg) => MessageBox.Show(msg, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
