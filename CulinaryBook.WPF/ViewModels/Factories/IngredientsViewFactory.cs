using CulinaryBook.ConsoleApp.Services.IngredientServices;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class IngredientsViewFactory : IViewModelFactory<IngredientsViewModel>
    {
        private readonly IIngredientDataService _service;

        public IngredientsViewFactory(IIngredientDataService service)
        {
            _service = service;
        }

        public IngredientsViewModel CreateViewModel()
        {
            return new IngredientsViewModel(_service);
        }
    }
}