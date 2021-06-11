using System.Windows.Input;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels.Factories;

namespace CulinaryBook.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; }
        public IAuthenticator Authenticator { get; }
        
        public ICommand UpdateCurrentViewModelCommand { get; }
        
        public ICommand LogoutCommand { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator, 
            IViewModelAbstractFactory viewModelAbstractFactory)
        {
            Navigator = navigator;
            Authenticator = authenticator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelAbstractFactory);
            LogoutCommand = new LogoutCommand(Authenticator, Navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }

    }
}