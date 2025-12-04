using CslaExemple.BLLNetStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public class ResourceDetailViewModel : INotifyPropertyChanged
    {
        public ResourceEdit _modelEdit;
        public ResourceEdit ModelEdit
        {
            get => _modelEdit;
            set { _modelEdit = value; OnPropertyChanged(nameof(ModelEdit)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
