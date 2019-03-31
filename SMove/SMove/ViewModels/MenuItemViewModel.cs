namespace SMove.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using SMove.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

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
            if (this.PageName == "EnterPage")
            {
                Application.Current.MainPage = new EnterPage();
            }
        }
        #endregion
    }
}
