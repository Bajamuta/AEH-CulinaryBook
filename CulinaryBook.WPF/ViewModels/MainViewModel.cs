using System.Windows.Input;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels.Factories;

namespace CulinaryBook.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewModelAbstractFactory _viewModelAbstractFactory;
        public INavigator Navigator { get; }
        public IAuthenticator Authenticator { get; }
        
        public ICommand UpdateCurrentViewModelCommand { get; }
        
        public ICommand LogoutCommand { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator, 
            IViewModelAbstractFactory viewModelAbstractFactory)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelAbstractFactory);
            LogoutCommand = new LogoutCommand(Authenticator, Navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }

    }
}