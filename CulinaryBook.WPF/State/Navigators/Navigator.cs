using System.Windows.Input;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.State.Navigators
{
    public class Navigator : INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
    }
}