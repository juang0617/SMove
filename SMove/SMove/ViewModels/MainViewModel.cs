

namespace SMove.ViewModels
{
    using System;
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
            this.LoadMenu();
        }
        #endregion
        #region Metodos
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_home",
                PageName = "MainPage",
                Title = "Inicio"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_assignment",
                PageName = "HistorialPage",
                Title = "Mis Viajes"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_credit_card",
                PageName = "PagosPage",
                Title = "Pago"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_perm_identity",
                PageName = "ProfilePage",
                Title = "Perfil"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_info_outline",
                PageName = "AboutUsPage",
                Title = "Sobre nosotros"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "EnterPage",
                Title = "Salir"
            });
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
