namespace SMove.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class RegisterViewModel : BaseViewModel
    {
        #region Atributos
        private string email;
        private string password;
        private string nombre;
        private string apellidos;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string Apellidos
        {
            get { return this.apellidos; }
            set { SetValue(ref this.apellidos, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRemembered { get; set; }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructores
        public RegisterViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion
        #region Comandos
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        public ICommand LoginLCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Register()
        {
            MainViewModel.GetInstance().Enter = new EnterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EnterPage());
        }

        private async void Login()
        {
            MainViewModel.GetInstance().Login = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        #endregion
    }
}
