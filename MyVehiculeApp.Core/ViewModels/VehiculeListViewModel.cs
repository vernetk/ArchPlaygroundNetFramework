using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.Core.ViewModels
{
    public class VehiculeListViewModel : INotifyPropertyChanged
    {
        private string _searchImmat;
        private string _searchSearchMarque;
        private BindingList<VehiculeListItemViewModel> _items
            = new BindingList<VehiculeListItemViewModel>();

        public string SearchImmatriculation
        {
            get => _searchImmat;
            set { _searchImmat = value; OnPropertyChanged(nameof(SearchImmatriculation)); }
        }

        public string SearchMarque
        {
            get => _searchSearchMarque;
            set { _searchSearchMarque = value; OnPropertyChanged(nameof(SearchMarque)); }
        }

        public BindingList<VehiculeListItemViewModel> Items { get; } = new BindingList<VehiculeListItemViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
