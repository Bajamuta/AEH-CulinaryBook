using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class BooksViewFactory : IViewModelFactory<BooksViewModel>
    {
        private readonly IBookDataService _service;
        private readonly IAuthenticator _authenticator;

        public BooksViewFactory(IBookDataService service, 
            IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
        }
        public BooksViewModel CreateViewModel()
        {
            return new BooksViewModel(_service, _authenticator);
        }
    }
}