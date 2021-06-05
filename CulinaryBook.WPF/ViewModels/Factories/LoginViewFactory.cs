namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class LoginViewFactory : IViewModelFactory<LoginViewModel>
    {
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel();
        }
    }
}