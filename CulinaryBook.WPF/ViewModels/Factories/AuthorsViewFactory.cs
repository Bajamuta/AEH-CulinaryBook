namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class AuthorsViewFactory : IViewModelFactory<AuthorsViewModel>
    {
        public AuthorsViewModel CreateViewModel()
        {
            return new AuthorsViewModel();
        }
    }
}