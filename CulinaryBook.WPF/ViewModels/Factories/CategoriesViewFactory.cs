namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class CategoriesViewFactory : IViewModelFactory<CategoriesViewModel>
    {
        public CategoriesViewModel CreateViewModel()
        {
            return new CategoriesViewModel();
        }
    }
}