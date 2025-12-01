using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehiculeApp.Core.ViewModels
{
    public class VehiculeDetailViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _immat;
        public string Immatriculation
        {
            get => _immat;
            set { _immat = value; OnPropertyChanged(nameof(Immatriculation)); }
        }

        private string _marque;
        public string Marque
        {
            get => _marque;
            set { _marque = value; OnPropertyChanged(nameof(Marque)); }
        }

        private string _modele;
        public string Modele
        {
            get => _modele;
            set { _modele = value; OnPropertyChanged(nameof(Modele)); }
        }

        private DateTime _dateEntreeParc = DateTime.Now;
        public DateTime DateEntreeParc
        {
            get => _dateEntreeParc;
            set { _dateEntreeParc = value; OnPropertyChanged(nameof(DateEntreeParc)); }
        }

        // 🔥 Si d'autres champs (Couleur, Modele, etc.) — ils vont ici

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
