

namespace SMove.ViewModels
{

    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        #region Propiedades
        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion
        #region ViewModels
        public LoginViewModel Login {
            get;
            set;
        }

        public EnterViewModel Enter {
            get;
            set;
        }

        public RegisterViewModel Register
        {
            get;
            set;
        }

        public MainPViewModel MainPage {
            get;
            set;
        }

        public ProfileViewModel Profile
        {
            get;
            set;
        }
        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.Enter = new EnterViewModel();
            this.Register = new RegisterViewModel();
            this.MainPage = new MainPViewModel();
            this.Profile = new ProfileViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
