using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class StepsViewFactory : IViewModelFactory<StepsViewModel>
    {
        private readonly IStepService _service;
        private readonly IAuthenticator _authenticator;

        public StepsViewFactory(IStepService service, 
            IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
        }
        public StepsViewModel CreateViewModel()
        {
            return new StepsViewModel(_service, _authenticator);
        }
    }
}