namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class HomeViewFactory : IViewModelFactory<HomeViewModel>
    {
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}