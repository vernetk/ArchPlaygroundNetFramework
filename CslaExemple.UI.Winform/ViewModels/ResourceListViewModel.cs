using CslaExemple.BLLNetStandard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.UI.Winform
{
    public class ResourceListViewModel : INotifyPropertyChanged
    {
        private string _searchFirstName;
        private string _searchSearchLastName;
        private BindingList<ResourceInfo> _items = new BindingList<ResourceInfo>();

        public string SearchFirstName
        {
            get => _searchFirstName;
            set { _searchFirstName = value; OnPropertyChanged(nameof(SearchFirstName)); }
        }

        public string SearchLastName
        {
            get => _searchSearchLastName;
            set { _searchSearchLastName = value; OnPropertyChanged(nameof(SearchLastName)); }
        }

        public BindingList<ResourceInfo> Items
        {
            get => _items;
            set
            {
                BindingList<ResourceInfo> result = new BindingList<ResourceInfo>();
                if (_items == value)
                    return;
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
