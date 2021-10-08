using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP3MVVM.Models;
using TP3MVVM.Services;
using TP3MVVM.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TP3MVVM.ViewModel
{
    class AddComptePageViewModel : ViewModelBase
    {
        public ICommand BtnAddCompteCommand { get; set; }
        public ICommand BtnClearCompteCommand { get; set; }

        private Compte compteToAdd{ get; set; }

        public Compte CompteToAdd
        {
            get { return compteToAdd; }
            set
            {
                compteToAdd = value;
                RaisePropertyChanged();
            }
        }

        public AddComptePageViewModel()
        {
            compteToAdd = new Compte();
            BtnAddCompteCommand = new RelayCommand(ActionAddCompte);
            BtnClearCompteCommand = new RelayCommand(ActionClearCompte);
        }

        private async void ActionAddCompte()
        {
            // Checking if CompteToAdd have all the informations needed
            if (string.IsNullOrEmpty(CompteToAdd.Nom) ||
                string.IsNullOrEmpty(CompteToAdd.Prenom) ||
                string.IsNullOrEmpty(CompteToAdd.Mel) ||
                string.IsNullOrEmpty(CompteToAdd.TelPortable) ||
                string.IsNullOrEmpty(CompteToAdd.Rue) ||
                string.IsNullOrEmpty(CompteToAdd.CodePostal) ||
                string.IsNullOrEmpty(CompteToAdd.Ville) ||
                string.IsNullOrEmpty(CompteToAdd.Pays) ||
                string.IsNullOrEmpty(CompteToAdd.Pwd)
                )
            {
                new ToastContentBuilder()
                  .AddText($"Erreur: Il manque des informations.")
                  .Show();
                return;
            }

            var latlng = await WSBingMaps.GetInstance().GetCoordinatesByCompte(CompteToAdd);
            CompteToAdd.Latitude = latlng[0];
            CompteToAdd.Longitude = latlng[1];

            if (await WSService.PostCompteAsync(CompteToAdd))
            {
                new ToastContentBuilder()
                   .AddText($"Enregistrement réussi avec lat : {CompteToAdd.Latitude} et lng : {CompteToAdd.Longitude}")
                   .Show();
            }
            else
            {
                new ToastContentBuilder()
                   .AddText("Echec lors de l'enregistrement")
                   .Show();
            }
        }

        private async void ActionClearCompte()
        {
            CompteToAdd = new Compte();
        }
    }
}
