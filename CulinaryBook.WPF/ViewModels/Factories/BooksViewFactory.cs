namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class BooksViewFactory : IViewModelFactory<BooksViewModel>
    {
        public BooksViewModel CreateViewModel()
        {
            return new BooksViewModel();
        }
    }
}