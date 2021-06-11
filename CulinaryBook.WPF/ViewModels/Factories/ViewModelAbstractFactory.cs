using System;
using CulinaryBook.WPF.State.Navigators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly IViewModelFactory<AuthorsViewModel> _authorsViewModelFactory;
        private readonly IViewModelFactory<BooksViewModel> _booksViewModelFactory;
        private readonly IViewModelFactory<CategoriesViewModel> _categoriesViewModelFactory;
        private readonly IViewModelFactory<IngredientsViewModel> _ingredientsViewModelFactory;
        private readonly IViewModelFactory<RecipesViewModel> _recipesViewModelFactory;
        private readonly IViewModelFactory<StepsViewModel> _stepsViewModelFactory;
        private readonly IViewModelFactory<LoginViewModel> _loginViewModelFactory;
        private readonly IViewModelFactory<LogoutViewModel> _logoutViewModelFactory;
        private readonly IViewModelFactory<ShowtimeViewModel> _showtimeViewModelFactory;

        public ViewModelAbstractFactory(
            IViewModelFactory<HomeViewModel> homeViewModelFactory, 
            IViewModelFactory<AuthorsViewModel> authorsViewModelFactory, 
            IViewModelFactory<BooksViewModel> booksViewModelFactory, 
            IViewModelFactory<CategoriesViewModel> categoriesViewModelFactory, 
            IViewModelFactory<IngredientsViewModel> ingredientsViewModelFactory, 
            IViewModelFactory<RecipesViewModel> recipesViewModelFactory, 
            IViewModelFactory<StepsViewModel> stepsViewModelFactory,
            IViewModelFactory<LoginViewModel> loginViewModelFactory, 
            IViewModelFactory<LogoutViewModel> logoutViewModelFactory, 
            IViewModelFactory<ShowtimeViewModel> showtimeViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _authorsViewModelFactory = authorsViewModelFactory;
            _booksViewModelFactory = booksViewModelFactory;
            _categoriesViewModelFactory = categoriesViewModelFactory;
            _ingredientsViewModelFactory = ingredientsViewModelFactory;
            _recipesViewModelFactory = recipesViewModelFactory;
            _stepsViewModelFactory = stepsViewModelFactory;
            _loginViewModelFactory = loginViewModelFactory;
            _logoutViewModelFactory = logoutViewModelFactory;
            _showtimeViewModelFactory = showtimeViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Books:
                    return _booksViewModelFactory.CreateViewModel();
                case ViewType.Categories:
                    return _categoriesViewModelFactory.CreateViewModel();
                case ViewType.Recipes:
                    return _recipesViewModelFactory.CreateViewModel();
                case ViewType.Ingredients:
                    return _ingredientsViewModelFactory.CreateViewModel();
                case ViewType.Authors:
                    return _authorsViewModelFactory.CreateViewModel();
                case ViewType.Steps:
                    return _stepsViewModelFactory.CreateViewModel();
                case ViewType.Showtime:
                    return _showtimeViewModelFactory.CreateViewModel();
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.Logout:
                    return _logoutViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("View Model error", nameof(viewType));
            }
        }
    }
}