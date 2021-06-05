namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class IngredientsViewFactory : IViewModelFactory<IngredientsViewModel>
    {
        public IngredientsViewModel CreateViewModel()
        {
            return new IngredientsViewModel();
        }
    }
}