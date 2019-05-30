namespace SMove.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using SMove.Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Helpers;
    using Models;

    public class MenuItemViewModel
    {
        #region Propiedades
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; } 
        #endregion

        #region Comandos
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;
            if (this.PageName == "EnterPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;

                using (var conn = new SQLite.SQLiteConnection(App.root_db))
                {
                    conn.DeleteAll<UserLocal>();
                }


                Application.Current.MainPage = new NavigationPage(new EnterPage());
            }

            else if (this.PageName == "ProfilePage")
            {
                MainViewModel.GetInstance().Profile = new ProfileViewModel();
                App.Navigator.PushAsync(new ProfilePage());
            }
        }
        #endregion
    }
}
