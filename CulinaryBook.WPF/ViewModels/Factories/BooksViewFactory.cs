using CulinaryBook.ConsoleApp.Services.BookServices;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class BooksViewFactory : IViewModelFactory<BooksViewModel>
    {
        private readonly IBookDataService _service;

        public BooksViewFactory(IBookDataService service)
        {
            _service = service;
        }
        public BooksViewModel CreateViewModel()
        {
            return new BooksViewModel(_service);
        }
    }
}