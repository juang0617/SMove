
namespace SMove.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class EnterViewModel : BaseViewModel
    {
        #region Atributos
        private bool isEnabled;
        #endregion

        #region Propiedades
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructores
        public EnterViewModel()
        {
            this.IsEnabled = true;
        }
        #endregion

        #region Comandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(EnterL);
            }
        }

        private async void EnterL()
        {
            MainViewModel.GetInstance().Enter = new EnterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public ICommand RegisCommand
        {
            get
            {
                return new RelayCommand(EnterR);
            }
        }
        private async void EnterR()
        {
            MainViewModel.GetInstance().Enter = new EnterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion
    }
}
