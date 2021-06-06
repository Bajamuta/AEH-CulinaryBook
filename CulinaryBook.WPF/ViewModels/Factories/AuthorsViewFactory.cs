using CulinaryBook.ConsoleApp.Services.AuthorServices;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class AuthorsViewFactory : IViewModelFactory<AuthorsViewModel>
    {
        private readonly IAuthorDataService _service;

        public AuthorsViewFactory(IAuthorDataService service)
        {
            _service = service;
        }
        public AuthorsViewModel CreateViewModel()
        {
            return new AuthorsViewModel(_service);
        }
    }
}