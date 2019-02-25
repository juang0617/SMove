
namespace SMove.ViewModels
{
    public class MainViewModel
    {
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
        #endregion

        #region Constructores
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.Enter = new EnterViewModel();
            this.Register = new RegisterViewModel();
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
