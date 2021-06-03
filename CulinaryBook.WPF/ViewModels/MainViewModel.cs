using CulinaryBook.WPF.State.Navigators;

namespace CulinaryBook.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}