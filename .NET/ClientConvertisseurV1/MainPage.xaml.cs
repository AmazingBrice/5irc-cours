using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Devise> Devises { get; set;  }

        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
        }

        private async void ActionGetData()
        {
            Devises = await WSService.GetAllDevisesAsync();
            this.cbxDevise.DataContext = Devises;
        }

        async void calculateButtonClick(object sender, RoutedEventArgs e)
        {
            int inputNumber;
            var success = Int32.TryParse(inputValue.Text, out inputNumber);
            if (!success)
            {
                await new MessageDialog("Invalid input value").ShowAsync();
                return;
            }
            var taux = Convert.ToDouble(cbxDevise.SelectedValue.ToString());
            resultBox.Text = (Convert.ToInt32(inputValue.Text) * taux).ToString();
        }
    }
}
