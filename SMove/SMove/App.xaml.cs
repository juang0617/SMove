using System;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SMove
{
    using Helpers;
    using Views;
    using ViewModels;
    using Xamarin.Forms;
    using Services;
    using Models;

    public partial class App : Application
    {
        #region Variables
        public static string root_db;
        #endregion

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

        //Builder overload - Get route db
        public App(string root_DB)
        {
            InitializeComponent();

            //Set root SQLite
            root_db = root_DB;

            //this.MainPage =new NavigationPage (new LoginPage());

            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new EnterPage());
            }
            else
            {
                //Connection with SQLite
                var user = new UserLocal();

                using (var conn = new SQLite.SQLiteConnection(App.root_db))
                {
                    conn.CreateTable<UserLocal>();
                    user = conn.Table<UserLocal>().FirstOrDefault();
                }

                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.User = user;//sqlite
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
