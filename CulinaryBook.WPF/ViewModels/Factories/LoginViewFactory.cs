using CulinaryBook.ConsoleApp.Services.LoginServices;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class LoginViewFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly ILoginService _service;

        public LoginViewFactory(ILoginService service)
        {
            _service = service;
        } 
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_service);
        }
    }
}