using MyVehiculeApp.Core.ViewModels;
using MyVehiculeApp.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVehiculeApp.UI
{
    public partial class VehiculeListForm : Form, IVehiculeListView
    {
        #region Events
        public event EventHandler SearchRequested;
        public event EventHandler<int> VehiculeSelected;
        public event EventHandler CreateRequested;
        #endregion Events

        #region VM
        public VehiculeListViewModel ViewModel { get; private set; }
        #endregion VM

        #region Ctrs
        public VehiculeListForm()
        {
            InitializeComponent();

            InitViewModel();
        }
        #endregion Ctrs

        #region VM methods
        public void InitViewModel()
        {
            ViewModel = new VehiculeListViewModel();

            txtImmatriculation.DataBindings.Add("Text", ViewModel, nameof(VehiculeListViewModel.SearchImmatriculation), true, DataSourceUpdateMode.OnPropertyChanged);
            txtMarque.DataBindings.Add("Text", ViewModel, nameof(VehiculeListViewModel.SearchMarque), true, DataSourceUpdateMode.OnPropertyChanged);

            gridVehicules.AutoGenerateColumns = true;
            gridVehicules.DataSource = ViewModel.Items;
        }
        #endregion VM methods

        #region Events view
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, EventArgs.Empty);
        }
        private void gridVehicules_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)gridVehicules.Rows[e.RowIndex].Cells["Id"].Value;
                VehiculeSelected?.Invoke(this, id);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateRequested?.Invoke(this, EventArgs.Empty);
        }
        #endregion Events view
    }
}
