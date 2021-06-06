using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CulinaryBook.WPF.Annotations;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}