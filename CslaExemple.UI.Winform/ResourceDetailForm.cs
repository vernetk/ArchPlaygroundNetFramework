using CslaExemple.BLLNetStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CslaExemple.UI.Winform
{
    public partial class ResourceDetailForm : Form, IResourceDetailView
    {
        public ResourceDetailViewModel ViewModel { get; private set; }

        public ResourceDetailForm()
        {
            InitializeComponent();

            ViewModel = new ResourceDetailViewModel();

            bindingSourceVM.DataSource = ViewModel;

            ResourceBindingSource.DataSource = bindingSourceVM;
            ResourceBindingSource.DataMember = nameof(ViewModel.ModelEdit);
        }


        public void ResourceDetailForm_Load (object sender, EventArgs e)
        {

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
                Text = "Créer une resource";
                btnSave.Text = "Créer";
            }
            else
            {
                Text = "Modifier une resource";
                btnSave.Text = "Enregistrer";
            }
        }
        public void SetError(string propertyName, string message)
        {
            switch (propertyName)
            {
                case nameof(ViewModel.ModelEdit.FirstName):
                    errorProvider.SetError(txtFirstName, message);
                    break;

                case nameof(ViewModel.ModelEdit.LastName):
                    errorProvider.SetError(txtLastName, message);
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
