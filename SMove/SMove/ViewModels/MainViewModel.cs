

namespace SMove.ViewModels
{
    using Domain;
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms.Maps;

    public class MainViewModel
    {
        #region Propiedades
        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }

        public string Token { get; set; }

        public string TokenType { get; set; }

        public UserLocal User
        {
            get;
            set;
        }

        public ObservableCollection<Pin> Pins { get; set; }
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
            Pins = new ObservableCollection<Pin>();
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

            //this.Menus.Add(new MenuItemViewModel
            //{
            //    Icon = "ic_assignment",
            //    PageName = "HistorialPage",
            //    Title = "Mis Viajes"
            //});

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_perm_identity",
                PageName = "ProfilePage",
                Title = "Perfil"
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "EnterPage",
                Title = "Salir"
            });
        }

        public void GetGeolocation()
        {
            var position1 = new Position(6.248754, -75.596131);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Casa",
                Address = "Mi Casa"
            };
            Pins.Add(pin1);

            var position2 = new Position(6.233063, -75.604972);
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "Los Molinos",
                Address = "C.C Los Molinos"
            };
            Pins.Add(pin2);

            var position3 = new Position(6.229012, -75.593821);
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "Pau",
                Address = "Casa Pau"
            };
            Pins.Add(pin3);

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
