

namespace SMove.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Services;
    using Helpers;

    public class LoginViewModel : BaseViewModel
    {
        #region Servicios
        private ApiService apiService;
        #endregion

        #region Atributos
        private string email;
        private string password;
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
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion
        #region Comandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand RegisterLCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    Languages.ValidacionCorreo,
                    Languages.Aceptar);
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    Languages.ValidacionContra, 
                    Languages.Aceptar);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    connection.Message,
                    Languages.Aceptar);
                return;
            }

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var token = await this.apiService.GetToken(
                apiSecurity,
                this.Email, 
                this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error, 
                    Languages.Fallo,
                    Languages.Aceptar);
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    token.ErrorDescription,
                    Languages.Aceptar);
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token.AccessToken;
            mainViewModel.TokenType = token.TokenType;

            if (this.IsRemembered)
            {
                Settings.Token = token.AccessToken;
                Settings.TokenType = token.TokenType;
            }
            
            Application.Current.MainPage = new MasterPage();

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            

        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion
    }
}
