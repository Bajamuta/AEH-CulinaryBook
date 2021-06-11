using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class MainViewFactory : IViewModelFactory<MainViewModel>
    {
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly IViewModelAbstractFactory _viewModelAbstractFactory;
        public MainViewFactory(INavigator navigator, IAuthenticator authenticator,
            IViewModelAbstractFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _authenticator = authenticator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }
        public MainViewModel CreateViewModel()
        {
            return new MainViewModel(_navigator, _authenticator, _viewModelAbstractFactory);
        }
    }
}