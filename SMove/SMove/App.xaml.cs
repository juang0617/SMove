using System;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SMove
{
    using Helpers;
    using Views;
    using ViewModels;
    using Xamarin.Forms;

    public partial class App : Application
    {
        #region Priopiedades
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
        public static MasterPage Master
        {
            get;
            internal set;
        }

        #endregion

        #region Constructor
        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new EnterPage());
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                this.MainPage = new MasterPage();
            }
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
