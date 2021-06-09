using CulinaryBook.WPF.ViewModels;
using CulinaryBook.WPF.ViewModels.Factories;

namespace CulinaryBook.WPF.State.Navigators
{
    public class Renavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IViewModelFactory<TViewModel> _viewModelAbstractFactory;

        public Renavigator(INavigator navigator, IViewModelFactory<TViewModel> viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel();
        }
    }
}