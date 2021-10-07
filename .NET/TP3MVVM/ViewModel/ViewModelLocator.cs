using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3MVVM.ViewModel
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ComptePageViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public ComptePageViewModel ComptePageVM =>
           ServiceLocator.Current.GetInstance<ComptePageViewModel>();
    }
}
