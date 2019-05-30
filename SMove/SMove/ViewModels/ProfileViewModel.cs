namespace SMove.ViewModels
{
    using Models;

    public class ProfileViewModel : BaseViewModel
    {
        public UserLocal User { get; set; }

        public ProfileViewModel()
        {
            this.User = MainViewModel.GetInstance().User;
        }
    }
}
