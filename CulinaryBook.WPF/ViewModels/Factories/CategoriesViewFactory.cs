using CulinaryBook.ConsoleApp.Services.CategoryServices;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class CategoriesViewFactory : IViewModelFactory<CategoriesViewModel>
    {
        private readonly ICategoryDataService _service;

        public CategoriesViewFactory(ICategoryDataService service)
        {
            _service = service;
        } 
        public CategoriesViewModel CreateViewModel()
        {
            return new CategoriesViewModel(_service);
        }
    }
}