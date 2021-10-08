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
    class SearchOrUpdateComptePageViewModel : ViewModelBase
    {
        public ICommand SearchButton { get; set; }
        public ICommand BtnModifyCompteCommand { get; set; }
        public ICommand BtnClearCompteCommand { get; set; }
        public ICommand BtnAddCompteCommand { get; set; }

        private Compte compteToSearchOrUpdate { get; set; }

        public Compte CompteToSearchOrUpdate
        {
            get { return compteToSearchOrUpdate; }
            set
            {
                compteToSearchOrUpdate = value;
                RaisePropertyChanged();
            }
        }

        public SearchOrUpdateComptePageViewModel()
        {
            compteToSearchOrUpdate = new Compte();
            SearchButton = new RelayCommand(ActionSearchByEmail);
            BtnModifyCompteCommand = new RelayCommand(ActionModifyCompte);
            BtnClearCompteCommand = new RelayCommand(ActionClearCompte);
            BtnAddCompteCommand = new RelayCommand(ActionAddCompte);
        }

        private async void ActionSearchByEmail()
        {
            CompteToSearchOrUpdate = await WSService.GetCompteByMailAsync(CompteToSearchOrUpdate.Mel);
        }

        private async void ActionModifyCompte()
        {
            if (CompteToSearchOrUpdate.CompteId == 0)
            {
                return;
            }

            if (await WSService.PutCompteAsync(CompteToSearchOrUpdate))
            {
                new ToastContentBuilder()
                   .AddText("Enregistrement réussi")
                   .Show(); ;
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
            CompteToSearchOrUpdate = new Compte();
        }

        private async void ActionAddCompte()
        {
            RootPage r = (RootPage) Window.Current.Content;
            SplitView sv = (SplitView)(r.Content);
            (sv.Content as Frame).Navigate(typeof(AddComptePage));
        }
    }
}
