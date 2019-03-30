using System;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SMove
{
    using SMove.Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        #region Priopiedades
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }

        #endregion

        #region Constructor
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new EnterPage());
        }
        #endregion

        #region Metodos
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
