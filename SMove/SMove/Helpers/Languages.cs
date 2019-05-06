using System;
using System.Collections.Generic;
using System.Text;

namespace SMove.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Aceptar
        {
            get { return Resource.Aceptar; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string ValidacionCorreo
        {
            get { return Resource.ValidacionCorreo; }
        }

        public static string ValidacionContra
        {
            get { return Resource.ValidacionContra; }
        }

        public static string Fallo
        {
            get { return Resource.Fallo; }
        }
    }
}
