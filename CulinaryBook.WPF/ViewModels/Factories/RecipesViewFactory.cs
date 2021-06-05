namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class RecipesViewFactory : IViewModelFactory<RecipesViewModel>
    {
        public RecipesViewModel CreateViewModel()
        {
            return new RecipesViewModel();
        }
    }
}