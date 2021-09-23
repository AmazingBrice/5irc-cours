using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModel
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ConvertisseurDeviseViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public ConvertisseurDeviseViewModel ConvertisseurDevise =>
           ServiceLocator.Current.GetInstance<ConvertisseurDeviseViewModel>();
    }
}
