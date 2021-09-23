using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    public class ConvertisseurDeviseViewModel : ViewModelBase
    {
        private ObservableCollection<Devise> comboBoxDevises;
        public ICommand BtnSetConversion { get; private set; }
        public ICommand BtnSetConversionReverse { get; private set; }

        private string montantInput;
        private Devise comboBoxDeviseItem;
        private string result;


        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return comboBoxDevises; }
            set
            {
                comboBoxDevises = value;
                RaisePropertyChanged();
            }
        }

        public string MontantInput
        {
            get { return montantInput; }
            set
            {
                montantInput = value;
                RaisePropertyChanged();
            }
        }

        public Devise ComboBoxDeviseItem
        {
            get { return comboBoxDeviseItem; }
            set
            {
                comboBoxDeviseItem = value;
                RaisePropertyChanged();
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                RaisePropertyChanged();
            }
        }

        public ConvertisseurDeviseViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
            BtnSetConversionReverse = new RelayCommand(ActionSetConversionReverse);
        } 

        private async void ActionGetData()
        {
            var result = await WSService.GetAllDevisesAsync();
            ComboBoxDevises = new ObservableCollection<Devise>(result);
        }

        private async void ActionSetConversion()
        {
            var montantInputNumber = await GetMontantInput();
            var taux = Convert.ToDouble(ComboBoxDeviseItem.Taux);
            Result = (montantInputNumber * taux).ToString();
        }

        private async void ActionSetConversionReverse()
        {
            var montantInputNumber = await GetMontantInput();
            var taux = Convert.ToDouble(ComboBoxDeviseItem.Taux);
            Result = (montantInputNumber / taux).ToString();
        }

        private async Task<Int32> GetMontantInput()
        {
            int inputNumber;
            var success = Int32.TryParse(MontantInput, out inputNumber);
            if (!success)
            {
                await new MessageDialog("Invalid input value").ShowAsync();
                return default(Int32);
            }
            return inputNumber;
        }
    }
}
