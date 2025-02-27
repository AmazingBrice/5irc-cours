﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TP3MVVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RootPage : Page
    {
        public RootPage(Frame frame)
        {
            this.InitializeComponent();

            this.MySplitView.Content = frame;
            (MySplitView.Content as Frame).Navigate(typeof(HomePage));
        }

        public void ToggleHamburger(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        public void GoBackClick(object sender, RoutedEventArgs e)
        {
            Frame myFrame = this.MySplitView.Content as Frame;
            if (myFrame != null && myFrame.CanGoBack)
            {
                myFrame.GoBack();
            }
        }

        private void GoToMenuCompte(object sender, RoutedEventArgs e)
        {
            (MySplitView.Content as Frame).Navigate(typeof(SearchOrUpdateComptePage));
        }
    }
}
