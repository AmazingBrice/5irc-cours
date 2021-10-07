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
using Windows.UI.Xaml.Controls;

namespace TP3MVVM.ViewModel
{
    class ComptePageViewModel : ViewModelBase
    {
        public ICommand SearchButton { get; set; }
        public ICommand BtnModifyCompteCommand { get; set; }
        public ICommand BtnClearCompteCommand { get; set; }
        public ICommand BtnAddCompteCommand { get; set; }

        private Compte searchCompte { get; set; }

        public Compte SearchCompte
        {
            get { return searchCompte; }
            set
            {
                searchCompte = value;
                RaisePropertyChanged();
            }
        }

        public ComptePageViewModel()
        {
            searchCompte = new Compte();
            SearchButton = new RelayCommand(ActionSearchByEmail);
            BtnModifyCompteCommand = new RelayCommand(ActionModifyCompte);
            BtnClearCompteCommand = new RelayCommand(ActionClearCompte);
            BtnAddCompteCommand = new RelayCommand(ActionAddCompte);
        }

        private async void ActionSearchByEmail()
        {
            SearchCompte = await WSService.GetCompteByMailAsync(SearchCompte.Mel);
        }

        private async void ActionModifyCompte()
        {
            if (SearchCompte.CompteId == 0)
            {
                return;
            }

            if (await WSService.PutCompteAsync(SearchCompte))
            {
                new ToastContentBuilder()
                   .AddText("Enregistrement réussi")
                   .Show(); ;
            }
            else
            {
                new ToastContentBuilder()
                   .AddText("Echec lors de l'enregistrement")
                   .Show(); ;
            }


           
        }

        private async void ActionClearCompte()
        {
            SearchCompte = new Compte();
        }

        private async void ActionAddCompte()
        {
            await WSService.PostCompteAsync(SearchCompte);
        }
    }
}
