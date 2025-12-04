using CslaExemple.UI.Winform;
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
    public partial class ResourceListForm : Form, IResourceListView
    {
        #region Events
        public event EventHandler SearchRequested;
        public event EventHandler<int> ResourceSelected;
        public event EventHandler CreateRequested;
        #endregion Events

        #region VM
        public ResourceListViewModel ViewModel { get; private set; }
        #endregion VM

        #region Ctrs
        public ResourceListForm()
        {
            InitializeComponent();

            InitViewModel();
        }
        #endregion Ctrs

        #region VM methods
        public void InitViewModel()
        {
            ViewModel = new ResourceListViewModel();

            txtFirstName.DataBindings.Add("Text", ViewModel, nameof(ResourceListViewModel.SearchFirstName), true, DataSourceUpdateMode.OnPropertyChanged);
            txtLastName.DataBindings.Add("Text", ViewModel, nameof(ResourceListViewModel.SearchLastName), true, DataSourceUpdateMode.OnPropertyChanged);

            gridResources.AutoGenerateColumns = true;
            gridResources.DataSource = ViewModel.Items;
        }
        #endregion VM methods

        #region Events view
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, EventArgs.Empty);
        }
        private void gridResources_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)gridResources.Rows[e.RowIndex].Cells["Id"].Value;
                ResourceSelected?.Invoke(this, id);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateRequested?.Invoke(this, EventArgs.Empty);
        }
        #endregion Events view
    }
}
