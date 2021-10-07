using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP3MVVM.Services;
using Windows.UI.Xaml.Controls;

namespace TP3MVVM.ViewModel
{
    class ComptePageViewModel : ViewModelBase
    {
        public ICommand SearchButton { get; set; }
        public string SearchMail { get; set; }
        public string nom;
        public string prenom;
        public string portable;
        public string mail;
        public string adresse;
        public string cp;
        public string ville;
        public string pays;

        public string Nom
        {
            get { return nom; }
            set
            {
                nom = value;
                RaisePropertyChanged();
            }
        }

        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                RaisePropertyChanged();
            }
        }

        public string Portable
        {
            get { return portable; }
            set
            {
                portable = value;
                RaisePropertyChanged();
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                RaisePropertyChanged();
            }
        }

        public string Adresse
        {
            get { return adresse; }
            set
            {
                adresse = value;
                RaisePropertyChanged();
            }
        }

        public string CP
        {
            get { return cp; }
            set
            {
                cp = value;
                RaisePropertyChanged();
            }
        }

        public string Ville
        {
            get { return ville; }
            set
            {
                ville = value;
                RaisePropertyChanged();
            }
        }

        public string Pays
        {
            get { return pays; }
            set
            {
                pays = value;
                RaisePropertyChanged();
            }
        }

        public ComptePageViewModel()
        {
            SearchButton = new RelayCommand(ActionSearchByEmail);
        }

        private async void ActionSearchByEmail()
        {
            var compte = await WSService.GetCompteByMailAsync(SearchMail);

            Nom = compte.Nom;
            Prenom = compte.Prenom;
            Portable = compte.TelPortable;
            Mail = compte.Mel;
            Adresse = compte.Rue;
            CP = compte.CodePostal;
            Ville = compte.Ville;
            Pays = compte.Pays;
        }
    }
}
